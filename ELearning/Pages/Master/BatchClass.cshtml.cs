using AspNetCoreHero.ToastNotification.Abstractions;
using ELearning.Interface;
using ELearning.Services;
using ELearning.SharedFileUpload;
using ELearning_Core.Model;
using ELearning_Core.Model.Faculty;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ELearning.Pages.Master
{
    public class BatchClassModel : PageModel
    {
        public readonly IBatchService _batchService;
        public readonly IMasterService _masterService;
        private readonly INotyfService _notyf;
        private readonly UserManager<IdentityUser> _UserManager;
        public readonly IFileUploadSerVices _fileUploadSerVices;
        public BatchClassModel(IBatchService batchService,IMasterService masterService, INotyfService notyf, UserManager<IdentityUser> userManager, IFileUploadSerVices fileUploadSerVices)
        {
            _batchService = batchService;
            _notyf = notyf;
            _UserManager = userManager;
            _fileUploadSerVices = fileUploadSerVices;
            _masterService = masterService;
        }
        [Parameter]
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string userId { get; set; }
        public string value { get; set; } = "Save";
        public string ImagePath { get; set; }
        [BindProperty]
        public BatchClass BatchClass { get; set; } = new();
        public List<BatchClass> BatchClasses { get; set; } = new();
        public List<Subject> GetSubjects { get; set; } = new(); 
        public List<Batch> GetBatches { get; set; } = new();    
        public  async Task OnGetAsync(int Id)
        {
            await getSubjects();
            await getBatches();
            BatchClasses = await _batchService.GetBatcheClasses();
            if(Id>0)
            {
                var batchData=BatchClasses.Where(x=>x.Id==Id).FirstOrDefault();
                if (batchData != null)
                {
                    BatchClass.Id = batchData.Id;
                    BatchClass.ClassName = batchData.ClassName;
                    BatchClass.BatchId = batchData.BatchId;
                    BatchClass.SubjectId = batchData.SubjectId;
                    BatchClass.YouTubeLink = batchData.YouTubeLink;
                    BatchClass.IsPaid = batchData.IsPaid;
                    BatchClass.Image= batchData.Image;
                    BatchClass.CreatedBy= batchData.CreatedBy;
                    BatchClass.CreatedDate= batchData.CreatedDate;
                    BatchClass.UpdatedDate= batchData.UpdatedDate;
                    BatchClass.UpdatedBy= batchData.UpdatedBy;
                    FilePath= batchData.Image;
                }
                value = "Update";
            }
        }

        public async Task getSubjects()
        {
            var subjectsList = await _masterService.GetSubjects();
            GetSubjects = subjectsList.Where(s => s.IsActive == true).ToList();
        }
        public async Task getBatches()
        {
            var batchList=await _masterService.GetBatches();
            GetBatches=batchList.ToList();
        }
        public async Task<IActionResult> OnPostAsync(IFormFile formFile, string targetFolder)
        {
            if (formFile != null)
            {
                FilePath = await _fileUploadSerVices.UplodeFileAsync(formFile, targetFolder);
            }
            var user = _UserManager.GetUserId(User);
            userId = user;
            if(BatchClass.Id==0)
            {
                string filename=Path.GetFileName(FilePath);
                BatchClass.CreatedBy = user;
                BatchClass.CreatedDate=DateTime.Now;
                BatchClass.Image = filename;
                var data=await _batchService.InsertBatchClass(BatchClass);
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
                    BatchClass.Image = filename;
                }
                BatchClass.UpdatedBy = user;
                BatchClass.UpdatedDate = DateTime.Now;
                BatchClass.Image = filename;
                var data = await _batchService.UpdateBatchClass(BatchClass);
                if (data.Succeeded)
                {
                    _notyf.Success(data.Messages[0]);
                }
                else
                {
                    _notyf.Error(data.Messages[0]);
                }
            }
            return Redirect("BatchClass");
        }
        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var data =await _batchService.DeleteBatchClass(Id);
            if (data.Succeeded)
            {
                _notyf.Success(data.Messages[0]);
            }
            else
            {
                _notyf.Error(data.Messages[0]);
            }
           return Redirect("BatchClass");
        }
    }
}
