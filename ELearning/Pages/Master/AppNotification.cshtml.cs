using AspNetCoreHero.ToastNotification.Abstractions;
using ELearning.Interface;
using ELearning_Core.Model;
using ELearning_Core.Model.Master;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ELearning.Course_Img_Service;

namespace ELearning.Pages.Master
{
    public class AppNotificationModel : PageModel
    {
        public readonly IMasterService _MasterService;
        private readonly INotyfService _notyf;
        private UserManager<IdentityUser> _UserManager;
        public readonly IFileUplodeService _fileUplodeService;
        public AppNotificationModel(IMasterService masterService, INotyfService notyf, UserManager<IdentityUser> userManager, IFileUplodeService fileUplodeService)
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
        public AppNotification notification { get; set; } = new();

        public List<AppNotification> GetAppNotifications { get; set; } = new();
        public async Task OnGetAsync(int Id)
        {
            GetAppNotifications = await _MasterService.GetNotification();
            if (Id > 0)
            {
                var appNotificationdata = GetAppNotifications.Where(x => x.Id == Id).FirstOrDefault();

                if (appNotificationdata != null)
                {
                    notification.Id = appNotificationdata.Id;
                    notification.Subject = appNotificationdata.Subject;
                    notification.Description = appNotificationdata.Description;
                    notification.Image = appNotificationdata.Image;
                    notification.IsActive = appNotificationdata.IsActive;
                    notification.CreatedDate = appNotificationdata.CreatedDate;
                    notification.CreatedBy = appNotificationdata.CreatedBy;
                    notification.UpdatedBy =   appNotificationdata.UpdatedBy;
                    notification.UpdatedDate = appNotificationdata.UpdatedDate;
                    IMagePath = appNotificationdata.Image;

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

            if (notification.Id == 0)
            {
                string fileName = Path.GetFileName(FilePath);
                notification.CreatedBy = user;
                notification.CreatedDate = DateTime.Now;
                notification.Image = fileName;
                var data = await _MasterService.InsertNotification(notification);
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
                    notification.Image = fileName;
                }

                notification.UpdatedBy = user;
                notification.UpdatedDate = DateTime.Now;
                var data = await _MasterService.UpdateNotification(notification);
                if (data.Succeeded)
                {
                    _notyf.Success(data.Messages[0]);
                }
                else
                {
                    _notyf.Error(data.Messages[0]);
                }
            }

            return Redirect("AppNotification");
        }

        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var data = await _MasterService.DeleteNotification(Id);
            if (data.Succeeded)
            {
                _notyf.Success(data.Messages[0]);
            }
            else
            {
                _notyf.Error(data.Messages[0]);
            }
            return Redirect("AppNotification");
        }
    }
}
