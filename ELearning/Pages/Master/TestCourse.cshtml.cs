using AspNetCoreHero.ToastNotification.Abstractions;
using ELearning.Course_Img_Service;
using ELearning.Interface;
using ELearning_Core.Model;
using ELearning_Core.Model.Master;
using ELearning_Core.Procedure;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace ELearning.Pages.Master
{
    public class TestCourseModel : PageModel
    {
        //public readonly IMasterService _MasterService;
        //private readonly INotyfService _notyf;
        //private UserManager<IdentityUser> _UserManager;
        //public readonly IFileUplodeService _fileUplodeService;
        //public TestCourseModel(IMasterService masterService, INotyfService notyf, UserManager<IdentityUser> userManager, IFileUplodeService fileUplodeService)
        //{
        //    _MasterService = masterService;
        //    _notyf = notyf;
        //    _UserManager = userManager;
        //    _fileUplodeService = fileUplodeService;
        ////}
        //[Parameter]
        //public int Id { get; set; }
        //public string FilePath { get; set; }
        //public string userId { get; set; }
        //public string value { get; set; } = "Save";
        //public string IMagePath { get; set; }
        //[BindProperty]
        //public Course course { get; set; } = new ();
      //  DataTable Data = new DataTable();
        public DataTable Data { get; set; }
        public List<Course> GetCourses { get; set; } = new();
        public async Task  OnGetAsync(int Id)
        {
            GetCourse GetCourse = new GetCourse();
            try
            {
                Data = GetCourse.getCoures();
            }
            catch (Exception ex)
            {

            }


        }

       
    }
}
