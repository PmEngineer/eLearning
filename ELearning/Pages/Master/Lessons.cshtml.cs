using ELearning_Core.Model;
using ELearning_Core.Core.Model;
using ELearning.Interface;
using Microsoft.AspNetCore.Components;
using ELearning_Core.Model.Master;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace ELearning.Pages.Master
{

    public class LessonsModel : PageModel
    {
        public readonly IMasterService _MasterService;
        private readonly INotyfService _notyf;
        private UserManager<IdentityUser> _UserManager;
        public LessonsModel(IMasterService masterService,INotyfService notyf,UserManager<IdentityUser> UserManager)
        {
            _MasterService = masterService;
            _notyf = notyf;
            _UserManager = UserManager;
        }
    
        public int submenuId { get; set; } = 29;
        public string userId { get; set; }
        [BindProperty]
        public Lessons lesson { get; set; } = new();
        public List<Lessons> lessons { get; set; } = new();
        public List<Subject> subjects { get; set; } = new();

        [Parameter] public int Id { get; set; }
        public string value { get; set; } = "Save";
        public async Task OnGetAsync(int Id)
        {
            var user = _UserManager.GetUserId(User);
            userId = user;
            await getData();
            await getsubjects();
            if (Id > 0)
            {
                var lessondata = lessons.Where(s => s.Id == Id).FirstOrDefault();
                if (lessondata != null)
                {
                    lesson.Id = lessondata.Id;
                    lesson.Name = lessondata.Name;
                    lesson.SubjectId = lessondata.SubjectId;
                    lesson.HindiName = lessondata.HindiName;
                    lesson.IsActive = lessondata.IsActive;
                    lesson.CreatedDate = lessondata.CreatedDate;
                    lesson.CreatedBy = lessondata.CreatedBy;

                }
                value = "Update";
            }
            else
            {
                lesson.IsActive = true;
            }
        }

        public async Task getData()
        {
            lessons = await _MasterService.GetLessons();
        }
        public async Task getsubjects()
        {
            var subjectsList = await _MasterService.GetSubjects();
            subjects = subjectsList.Where(s=>s.IsActive==true).ToList();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var user = _UserManager.GetUserId(User);
            userId = user;
            if (lesson.Id == 0)
            {
                lesson.CreatedDate = DateTime.Now;
                lesson.CreatedBy = _UserManager.GetUserId(User);
                var data = await _MasterService.InsertLessons(lesson);
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
                lesson.UpdatedDate = DateTime.Now;
                lesson.UpdatedBy = _UserManager.GetUserId(User);
                var data = await _MasterService.UpdateLessons(lesson);
                if (data.Succeeded)
                {
                    _notyf.Success(data.Messages[0]);
                }
                else
                {
                    _notyf.Error(data.Messages[0]);
                }
            }
            await Reset();
            return Redirect("Lessons");
        }
        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var data = await _MasterService.DeleteLesson(Id);
            if (data.Succeeded)
            {
                _notyf.Success(data.Messages[0]);
            }
            else
            {
                _notyf.Error(data.Messages[0]);
            }
            await Reset();
            await OnGetAsync(0);

            return Redirect("Lessons");
        }
        public async Task Reset()
        {
            ModelState.Clear();
            lesson = new Lessons();
            await getData();
            await getsubjects();
           
        }
    }
}
