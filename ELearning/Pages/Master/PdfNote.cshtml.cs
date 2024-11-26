using AspNetCoreHero.ToastNotification.Abstractions;
using ELearning.Interface;
using ELearning.SharedFileUpload;
using ELearning_Core.Model;
using ELearning_Core.Model.Master;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ELearning.Pages.Master
{
    public class PdfNoteModel : PageModel
    {

        public readonly IMasterService _MasterService;
        private readonly INotyfService _notfy;
        private readonly UserManager<IdentityUser> _UserManager;
        public readonly IFileUploadSerVices _fileUploadSerVices;
        public PdfNoteModel(IMasterService masterService, INotyfService notyf, UserManager<IdentityUser> userManager, IFileUploadSerVices fileUploadSerVices)
        {
            _MasterService = masterService;
            _notfy = notyf;
            _UserManager = userManager;
            _fileUploadSerVices = fileUploadSerVices;

        }
        [Parameter]
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string userId { get; set; }
        public string value { get; set; } = "Save";
        public string pdfFilePath { get; set; }
        [BindProperty]
        public PdfNote pdfNote { get; set; } = new();
        public List<Course> GetCourses { get; set; } = new();
        public List<PdfNote> pdfNotes { get; set; } = new();

        public async Task OnGetAsync(int Id)
        {
            await getCourses();
            pdfNotes = await _MasterService.GetPdfNotes();
            if (Id > 0)
            {
                var pdfdata = pdfNotes.Where(x => x.Id == Id).FirstOrDefault();
                if (pdfdata != null)
                {
                    pdfNote.Id = pdfdata.Id;
                    pdfNote.PdfFile = pdfdata.PdfFile;
                    pdfNote.NoteName = pdfdata.NoteName;
                    pdfNote.UpdatedDate = pdfdata.UpdatedDate;
                    pdfNote.CreatedDate = pdfdata.CreatedDate;
                    pdfNote.UpdatedBy = pdfdata.UpdatedBy;
                    pdfNote.CreatedBy = pdfdata.CreatedBy;
                    pdfNote.IsPaid = pdfdata.IsPaid;
                    pdfNote.CourseId = pdfdata.CourseId;
                    pdfFilePath = pdfdata.PdfFile;
                }
                value = "Update";
            }

         
        }
        public async Task getCourses()
        {
            var coursesList = await _MasterService.GetCourse();
            GetCourses = coursesList.ToList();
        }
        public async Task<IActionResult> OnPostAsync(IFormFile formFile,string targetFolder)
        {
            if(formFile != null)
            {
                FilePath = await _fileUploadSerVices.UplodeFileAsync(formFile,targetFolder);
            }
            var user = _UserManager.GetUserId(User);
            userId = user;
            if (pdfNote.Id == 0)
            {
                string filename = Path.GetFileName(FilePath);
                pdfNote.CreatedBy = user;
                pdfNote.CreatedDate=DateTime.Now;
                pdfNote.PdfFile=filename;

                var data = await _MasterService.InsertPdfNote(pdfNote);
                if (data.Succeeded)
                {
                    _notfy.Success(data.Messages[0]);
                }
                else
                {
                    _notfy.Error(data.Messages[0]); 
                }
            }
            else
            {
                string fileName = Path.GetFileName(FilePath);
                if(fileName != null)
                {
                    pdfNote.PdfFile = fileName;
                }
                pdfNote.UpdatedBy = user;
                pdfNote.UpdatedDate=DateTime.Now;
                var data=await _MasterService.UpdatePdfNote(pdfNote);
                if (data.Succeeded)
                {
                    _notfy.Success(data.Messages[0]);
                }
                else
                {
                    _notfy.Error(data.Messages[0]);
                }
            }
            return Redirect("PdfNote");
        }
        public async Task<IActionResult> OnPostDelete(int Id)
        {
var data = await _MasterService.DeletePdfNote(Id);
            if (data.Succeeded) 
            {
                _notfy.Success(data.Messages[0]);
            }
            else
            {
                _notfy.Error(data.Messages[0]);
            }
            return Redirect("PdfNote");
        }
    }
}
