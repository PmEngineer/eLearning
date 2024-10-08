using AspNetCoreHero.ToastNotification.Abstractions;
using ELearning.Interface;
using ELearning_Core.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ELearning.Pages.Question_Bank
{
    public class QuestionsModel : PageModel
    {
        public readonly IMasterService _MasterService;
        private readonly INotyfService _notyf;
        private UserManager<IdentityUser> _UserManager;
        public QuestionsModel(IMasterService masterService, INotyfService notyf, UserManager<IdentityUser> UserManager)
        {
            _MasterService = masterService;
            _notyf = notyf;
            _UserManager = UserManager;
        }

        public List<Subject> subjects { get; set; } = new();
        public List<Lessons> GetLesson { get; set; } = new();
        public async Task OnGetAsync(int Id)
        {
            await getSubjects();
            await getLesssons();
        }

        public async Task getSubjects()
        {
            subjects = await _MasterService.GetSubjects();
        } 
        public async Task getLesssons()
        {
            GetLesson = await _MasterService.GetLessons();
        }


    }
}