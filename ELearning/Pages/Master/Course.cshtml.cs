using AspNetCoreHero.ToastNotification.Abstractions;
using ELearning.Course_Img_Service;
using ELearning.Interface;
using ELearning_Core.Model;
using ELearning_Core.Model.Master;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ELearning.Pages.Master
{
    public class CourseModel : PageModel
    {
        public readonly IMasterService _MasterService;
        private readonly INotyfService _notyf;
        private UserManager<IdentityUser> _UserManager;
        public readonly IFileUplodeService _fileUplodeService;
        public CourseModel(IMasterService masterService, INotyfService notyf, UserManager<IdentityUser> userManager, IFileUplodeService fileUplodeService)
        {
            _MasterService = masterService;
            _notyf = notyf;
            _UserManager = userManager;
            _fileUplodeService = fileUplodeService;
        }
        [Parameter]
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string userId { get; set; }
        public string value { get; set; } = "Save";
        public string IMagePath { get; set; }
        [BindProperty]
        public Course course { get; set; } = new ();

        public List<Course> GetCourses { get; set; } = new();
        public async Task  OnGetAsync(int Id)
        {
            GetCourses = await _MasterService.GetCourse();
            if(Id >0)
            {
                var couesedata = GetCourses.Where(x => x.Id == Id).FirstOrDefault();
              
                if (couesedata != null)
                {
                    course.Id = couesedata.Id;
                    course.Name = couesedata.Name;
                    course.Discription = couesedata.Discription;
                    course.Support = couesedata.Support;
                    course.ISLive = couesedata.ISLive;
                    course.Fee = couesedata.Fee;
                    course.ISPaid = couesedata.ISPaid;
                    course.Image = couesedata.Image;
                    course.Rating = couesedata.Rating;
                    course.StartDate = couesedata.StartDate;
                    course.EndDate = couesedata.EndDate;
                    course.Validity = couesedata.Validity;
                    course.CreatedBy = couesedata.CreatedBy;
                    course.CreatedDate = couesedata.CreatedDate;
                    course.UpdatedBy = couesedata.UpdatedBy;
                    course.UpdatedDate = couesedata.UpdatedDate;
                    IMagePath = couesedata.Image;
               




                }
                value = "Update";
            }

        }

        public async Task<IActionResult> OnPostAsync(IFormFile formFile)
        {
            if (formFile != null)
            {
                FilePath = await _fileUplodeService.UplodeFileAsync(formFile);
            }
         
            var user = _UserManager.GetUserId(User);
            userId = user;

            if(course.Id == 0)
            {
                string fileName = Path.GetFileName(FilePath);
                course.CreatedBy = user;
                course.CreatedDate = DateTime.Now;
                course.Image = fileName;
                var data = await _MasterService.InsertCourse(course);
                if (data.Succeeded)
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
                string fileName = Path.GetFileName(FilePath);
                if (fileName != null)
                {
                    course.Image = fileName;
                }
           
                course.UpdatedBy = user;
                course.UpdatedDate = DateTime.Now;
                var data = await _MasterService.UpdateCourse(course);
                if (data.Succeeded)
                {
                    _notyf.Success(data.Messages[0]);
                }
                else
                {
                    _notyf.Error(data.Messages[0]);
                }
            }

            return Redirect("Course");
        }

        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var data = await _MasterService.DeleteCourse(Id);
            if (data.Succeeded)
            {
                _notyf.Success(data.Messages[0]);
            }
            else
            {
                _notyf.Error(data.Messages[0]);
            }
            return Redirect("Course");
        }
    }
}
