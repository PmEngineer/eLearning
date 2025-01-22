using AspNetCoreHero.ToastNotification.Abstractions;
using ELearning.Interface;
using ELearning.SharedFileUpload;
using ELearning_Core.Model;
using ELearning_Core.Model.Faculty;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ELearning.Pages.Master
{
    public class BatchNoteModel : PageModel
    {
        public readonly IBatchService _batchService;
        public readonly IMasterService _masterService;
        private readonly INotyfService _notyf;
        private readonly UserManager<IdentityUser> _UserManager;
        public readonly IFileUploadSerVices _fileUploadSerVices;
        public BatchNoteModel(IBatchService batchService, IMasterService masterService, INotyfService notyf, UserManager<IdentityUser> userManager, IFileUploadSerVices fileUploadSerVices)
        {
            _batchService = batchService;
            _masterService = masterService;
            _notyf = notyf;
            _UserManager = userManager;
            _fileUploadSerVices = fileUploadSerVices;
        }
        [Parameter]
        public int Id { get; set; }
        public string userId { get; set; }
        public string value { get; set; } = "Save";
        public string FilePath { get; set; }
        public string NotesFile { get; set; }
        [BindProperty]
        public BatchNote BatchNote { get; set; } = new();
        public List<BatchNote> BatchNotes{get;set; }=new();
        public List<Subject> GetSubjects { get; set; } = new();
        public List<Batch> GetBatches { get; set; } = new();
        public async Task OnGetAsync(int Id)
        {
            await getSubjects();
            await getBatches();
            BatchNotes = await _batchService.GetBatchNotes();
            if(Id>0)
            {
                var noteData = BatchNotes.Where(x => x.Id == Id).FirstOrDefault();
                if(noteData!=null)
                {
                    BatchNote.Id= noteData.Id;
                    BatchNote.SubjectId= noteData.SubjectId;
                    BatchNote.BatchId= noteData.BatchId;
                    BatchNote.Notes= noteData.Notes;
                    BatchNote.CreatedBy= noteData.CreatedBy;
                    BatchNote.CreatedDate= noteData.CreatedDate;
                    BatchNote.UpdatedBy= noteData.UpdatedBy;
                    BatchNote.UpdatedDate= noteData.UpdatedDate;
                    BatchNote.NoteFile= noteData.NoteFile;  
                    NotesFile = noteData.Notes; 
                }
                value="Update";
            }
        }
        public async Task getSubjects()
        {
            var subjectsList = await _masterService.GetSubjects();
            GetSubjects = subjectsList.Where(s => s.IsActive == true).ToList();
        }
        public async Task getBatches()
        {
            var batchList = await _masterService.GetBatches();
            GetBatches = batchList.ToList();
        }
        public async Task<IActionResult> OnPostAsync(IFormFile formFile, string targetFolder)
        {
            if(formFile !=null)
            {
                FilePath = await _fileUploadSerVices.UplodeFileAsync(formFile, targetFolder);
            }
            var user = _UserManager.GetUserId(User);
            userId = user;
            if(BatchNote.Id==0)
            {
                string filename = Path.GetFileName(FilePath);
                BatchNote.CreatedBy = user;
                BatchNote.CreatedDate = DateTime.Now;
                BatchNote.NoteFile = filename;
                var data = await _batchService.InsertBatchNote(BatchNote);
                if(data.Succeeded)
                {
                    _notyf.Success(data.Messages[0]);
                }
                else
                {
                    _notyf.Error(data.Messages[0]);
                }
            }
            else
            {
                string filename = Path.GetFileName(FilePath);
                if(filename!=null)
                {
                    BatchNote.NoteFile = filename;
                }
                BatchNote.UpdatedBy = user;
                BatchNote.UpdatedDate = DateTime.Now;
                var data = await _batchService.UpdateBatchNote(BatchNote);
                if (data.Succeeded)
                {
                    _notyf.Success(data.Messages[0]);
                }
                else
                {
                    _notyf.Error(data.Messages[0]);
                }
            }
            return Redirect("BatchNote");
        }
        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var data = await _batchService.DeleteBatchNote(Id);
            if (data.Succeeded)
            {
                _notyf.Success(data.Messages[0]);
            }
            else
            {
                _notyf.Error(data.Messages[0]);
            }
            return Redirect("BatchNote");
        }
    }
}
