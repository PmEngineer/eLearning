using AspNetCoreHero.ToastNotification.Abstractions;
using ELearning.Interface;
using ELearning_Core.Model.Faculty;
using ELearning_Core.Model.Master;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ELearning.Pages.Master
{
    public class BatchModel : PageModel
    {
        public readonly IMasterService _MasterService;
        private readonly INotyfService _notyf;
        private readonly UserManager<IdentityUser> _UserManager;
        public BatchModel(IMasterService masterService, INotyfService notyf, UserManager<IdentityUser> userManager)
        {
            _MasterService = masterService;
            _notyf = notyf;
            _UserManager = userManager;
        }
        [Parameter]
        public int Id { get; set; }

        public string userId { get; set; }
        public string value { get; set; } = "Save";
        [BindProperty]
        public Batch Batch { get; set; } = new();
        public List<Batch> Batches { get; set; } = new();
        public List<Course> GetCourses { get; set; } = new();
        public async Task OnGetAsync(int Id)
        {
            await getCourses();
            Batches= await _MasterService.GetBatches();
            if(Id>0)
            {
                var batchData = Batches.Where(x => x.Id == Id).FirstOrDefault();
                if (batchData != null)
                {
                    Batch.Id= batchData.Id;
                    Batch.CourseId = batchData.CourseId;
                    Batch.Name = batchData.Name;
                    Batch.StartDate = batchData.StartDate;
                    Batch.EndDate = batchData.EndDate;
                    Batch.Duration = batchData.Duration;
                    Batch.Validity = batchData.Validity;
                    Batch.CreatedBy = batchData.CreatedBy;
                    Batch.CreatedDate = batchData.CreatedDate;
                    Batch.UpdatedDate = batchData.UpdatedDate;
                    Batch.UpdatedBy = batchData.UpdatedBy;

                }
                value = "Update";
            }
        }
        public async Task getCourses()
        {
            var coursesList = await _MasterService.GetCourse();
            GetCourses = coursesList.ToList();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var user = _UserManager.GetUserId(User);
            userId = user;
            if (Batch.Id == 0)
            {
                Batch.CreatedBy=_UserManager.GetUserId(User);   
                Batch.CreatedDate=DateTime.Now;
                var data = await _MasterService.InsertBatch(Batch);
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
                Batch.UpdatedDate=DateTime.Now;
                Batch.UpdatedBy = _UserManager.GetUserId(User);
                var data= await _MasterService.UpdateBatch(Batch);
                if (data.Succeeded)
                {
                    _notyf.Success(data.Messages[0]);
                }
                else
                {
                    _notyf.Error(data.Messages[0]);
                }
            }
            return Redirect("Batch");
        }
        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var data = await _MasterService.DeleteBatch(Id);
            if (data.Succeeded)
            {
                _notyf.Success(data.Messages[0]);
            }
            else
            {
                _notyf.Error(data.Messages[0]);
            }
            return Redirect("Batch");
        }
    }
}
