using ELearning_Core.Model;
using ELearning.Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ELearning_Core.Model.Master;
using ELearning_Core.Model.City;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace ELearning.Pages.Master
{
   
    public class SubjectModel : PageModel
    {
        public readonly IMasterService _MasterService;
        private readonly INotyfService _notyf;
        private UserManager<IdentityUser> _UserManager;
        public SubjectModel(IMasterService masterService,INotyfService notyf, UserManager<IdentityUser> UserManager)
        {
            _MasterService = masterService;
            _notyf = notyf;
            _UserManager = UserManager;
        }
      
  
        public string userId { get; set; } 

        [BindProperty]
        public Subject subject { get; set; } = new();
        public List<Subject> subjects { get; set; } = new();
        [Parameter] public int Id { get; set; }
        public string value { get; set; } = "Save";
        public async Task OnGetAsync(int Id)
        {
            var user = _UserManager.GetUserId(User);
            userId = user;
            await getData();
            if (Id > 0)
            {
                var subjectdata = subjects.Where(c => c.Id == Id).FirstOrDefault();
                if (subjectdata != null)
                {
                    subject.Name = subjectdata.Name;
                    subject.HindiName = subjectdata.HindiName;

                    subject.Id = subjectdata.Id;
                    subject.IsActive = subjectdata.IsActive;
                    subject.CreatedDate = subjectdata.CreatedDate;
                    subject.CreatedBy = subjectdata.CreatedBy;
                }
                value = "Update";
            }
            else
            {
                subject.IsActive = true;
            }
        }

        public async Task getData()
        {
            subjects = await _MasterService.GetSubjects();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var user = _UserManager.GetUserId(User);
            userId = user;
            if (subject.Name == null || subject.Name == "")
            {
                _notyf.Error("Please Enter subject Name");
            }
            else
            {
                if (subject.Id == 0)
                {
                    subject.CreatedDate = DateTime.Now;
                    subject.CreatedBy = _UserManager.GetUserId(User);
                    var data = await _MasterService.InsertSubjects(subject);
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
                    subject.UpdatedDate = DateTime.Now;
                    subject.UpdatedBy = _UserManager.GetUserId(User);
                    var data = await _MasterService.UpdateSubjects(subject);
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
            }
            return Redirect("Subject");
        }
        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var data = await _MasterService.DeleteSubjects(Id);
            if (data.Succeeded)
            {
                _notyf.Success(data.Messages[0]);
            }
            else
            {
                _notyf.Error(data.Messages[0]);
            }
            await Reset();
            return Redirect("Subject");
        }

        public async Task Reset()
        {
            ModelState.Clear();

            await getData();
            subject = new Subject();
        }
    }
}
