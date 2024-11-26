using AspNetCoreHero.ToastNotification.Abstractions;
using ELearning.Course_Img_Service;
using ELearning.Interface;
using ELearning.SharedFileUpload;
using ELearning_Core.Model.Master;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.X509Certificates;

namespace ELearning.Pages.Master
{
    public class PreviousYearPaperModel : PageModel
    {
        public readonly IMasterService _MasterService;
        private readonly INotyfService _notyf;
        private UserManager<IdentityUser> _UserManager;
        public readonly IFileUploadSerVices _fileUploadSerVices;
        public PreviousYearPaperModel(IMasterService masterService, INotyfService notyf, UserManager<IdentityUser> userManager, IFileUploadSerVices fileUplodeServices)
        {
            _MasterService = masterService;
            _notyf = notyf;
            _UserManager = userManager;
            _fileUploadSerVices = fileUplodeServices;
        }
        [Parameter]
        public int Id {  get; set; }
        public string FilePath {  get; set; }
        public string userId {  get; set; }
        public string value { get; set; } = "Save";

        public List<Course> GetCourses { get; set; } = new();
        public string paperPath { get; set; }
        [BindProperty]
        public PreviousYearPaper paper { get; set; } = new();
        public List<PreviousYearPaper> papers { get; set; } = new();
        
        public async Task OnGetAsync(int Id)
        {
            await getCourses();
            papers = await _MasterService.GetPaperPdf();
            if(Id > 0)
            {
                var paperdata = papers.Where(x => x.Id == Id).FirstOrDefault(); 
                if(paperdata != null)
                {
                    paper.Id = paperdata.Id;
                    paper.CourseId = paperdata.CourseId;
                    paper.IsPaid = paperdata.IsPaid;
                    paper.NoteName = paperdata.NoteName;
                    paper.Year = paperdata.Year;
                    paper.UpdatedBy = paperdata.UpdatedBy;
                    paper.UpdatedDate = paperdata.UpdatedDate;
                    paper.CreatedBy = paperdata.CreatedBy;
                    paper.CreatedDate = paperdata.CreatedDate;
                    paper.Paperpdf = paperdata.Paperpdf;
                    paperPath = paperdata.Paperpdf;
        
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
                FilePath = await _fileUploadSerVices.UplodeFileAsync(formFile, targetFolder);
            }
            var user = _UserManager.GetUserId(User);
            userId = user;
            if(paper.Id == 0)
            {
                string filename = Path.GetFileName(FilePath);
                paper.CreatedBy = user;
                paper.CreatedDate = DateTime.Now;
                paper.Paperpdf = filename;
                var data = await _MasterService.InsertPaper(paper);
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
                if(filename !=null)
                {
                    paper.Paperpdf = filename;

                }
                paper.UpdatedBy = user;
                paper.UpdatedDate = DateTime.Now;
                var data = await _MasterService.UpdatePaper(paper);
                if (data.Succeeded)
                {
                    _notyf.Success(data.Messages[0]);
                }
                else
                {
                    _notyf.Error(data.Messages[0]);
                }
            }
            return Redirect("PreviousYearPaper");
        }
        public async Task<IActionResult> OnPostDelete(int Id)
                {
            var data = await _MasterService.DeletePaper(Id);
            if (data.Succeeded)
            {
                _notyf.Success(data.Messages[0]);
            }
            else
            {
                _notyf.Error(data.Messages[0]);
            }
            return Redirect("PreviousYearPaper");
        }
           
       
    }
}
