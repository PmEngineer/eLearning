using AspNetCoreHero.ToastNotification.Abstractions;
using ELearning.Interface;
using ELearning_Core.Model.Master;
using ELearning_Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO.Pipelines;

namespace ELearning.Pages.Student_Exam
{
    public class StudentPaperCreationModel : PageModel
    {
        public readonly IMasterService _masterService;
       
        private readonly INotyfService _notyf;
        public StudentPaperCreationModel(INotyfService notyfy, IMasterService masterService)
        {
            _notyf = notyfy;
            _masterService = masterService;
            
        }
        public List<Course> courses { get; set; }
        public List<Subject> subjects { get; set; }
        
        [BindProperty]
        public int Id { get; set; }
        public async Task OnGetAsync()
        {
            courses = await _masterService.GetCourse();
            subjects = await _masterService.GetSubjects();
            //await getPaper();
        }
        //public async Task getPaper()
        //{
        //    var data = await _StudentRepository.GetPaper();
        //    papers = data.Where(m => m.IsActive == true).ToList();
        //}
        //public async Task<IActionResult> OnPostDelete(int Id)
        //{
        //    var data = await _StudentRepository.DeletePaperDetail(Id);
        //    if (data.Succeeded)
        //    {
        //        _notyf.Success(data.Messages[0]);
        //    }
        //    else
        //    {
        //        _notyf.Error(data.Messages[0]);
        //    }
        //    // await Reset();

        //    //await OnGetAsync(0);
        //    return Redirect("StudentPaper");
        //}
    }
}
