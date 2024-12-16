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
    public class AppNotificationModel : PageModel
    {

        public readonly IMasterService _MasterService;
        private readonly INotyfService _notfy;
        private readonly UserManager<IdentityUser> _UserManger;
        public readonly IFileUploadSerVices _fileUploadSerVices;

        public AppNotificationModel(IMasterService masterService, INotyfService notfy, UserManager<IdentityUser> userManger, IFileUploadSerVices fileUploadSerVices)
        {
            _MasterService = masterService;
            _notfy = notfy;
            _UserManger = userManger;
            _fileUploadSerVices = fileUploadSerVices;
        }
        [Parameter]
        public int Id { get; set; }
        public string FilePath { get; set; }

        public string userId { get; set; }
        public string value { get; set; } = "Save";
        public string ImagePath { get; set; }
        [BindProperty]
        public AppNotification AppNotification { get; set; } = new();
        public List<AppNotification> AppNotifications { get; set; } = new();
        public List<Subject> GetSubjects { get; set; } = new();


        public async Task OnGetAsync(int Id)
        {
            await getSubjects();
            AppNotifications = await _MasterService.GetNotification();
            if (Id > 0)
            {
                var notficationData = AppNotifications.Where(x => x.Id == Id).FirstOrDefault();
                if (notficationData != null)
                {
                    AppNotification.Id = notficationData.Id;
                    AppNotification.SubjectId = notficationData.SubjectId;
                    AppNotification.Description = notficationData.Description;
                    AppNotification.Image = notficationData.Image;
                    AppNotification.IsActive = notficationData.IsActive;
                    ImagePath = notficationData.Image;
                    AppNotification.CreatedBy = notficationData.CreatedBy;
                    AppNotification.CreatedDate = notficationData.CreatedDate;
                    AppNotification.UpdatedBy = notficationData.UpdatedBy;
                    AppNotification.UpdatedDate = notficationData.UpdatedDate;

                }
                value = "Update";
            }
        }
        public async Task getSubjects()
        {
            var subjectList = await _MasterService.GetSubjects();
            GetSubjects = subjectList.Where(x => x.IsActive == true).ToList();
        }
        public async Task<IActionResult> OnPostAsync(IFormFile formfile, string targetFolder)
        {
            if (formfile != null)
            {
                FilePath = await _fileUploadSerVices.UplodeFileAsync(formfile, targetFolder);
            }
            var user = _UserManger.GetUserId(User);
            userId = user;
            if (AppNotification.Id == 0)
            {
                string filename = Path.GetFileName(FilePath);
                AppNotification.CreatedBy = user;
                AppNotification.CreatedDate = DateTime.Now;
                AppNotification.Image = filename;
                var data = await _MasterService.InsertNotification(AppNotification);
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
                string filename = Path.GetFileName(FilePath);
                if (filename != null)
                {
                    AppNotification.Image = filename;
                }
                AppNotification.UpdatedBy = user;
                AppNotification.UpdatedDate = DateTime.Now;
                var data = await _MasterService.UpdateNotification(AppNotification);
                if (data.Succeeded)
                {
                    _notfy.Success(data.Messages[0]);
                }
                else
                {
                    _notfy.Error(data.Messages[0]);
                }
            }

            return Redirect("AppNotification");
        }
        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var data = await _MasterService.DeleteNotification(Id);
            if (data.Succeeded)
            {
                _notfy.Success(data.Messages[0]);
            }
            else
            {
                _notfy.Error(data.Messages[0]);
            }
            return Redirect("AppNotification");
        }

    }
}
