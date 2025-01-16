using AspNetCoreHero.ToastNotification.Abstractions;
using ELearning.Interface;
using ELearning_Core.Model;
using ELearning_Core.Model.Faculty;
using ELearning_Core.Model.Master;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Utilities;

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
        public BatchSubject BatchSubject { get; set; } = new();
        public List<BatchSubject> BatchSubjects { get; set; } = new();
        [BindProperty]
        public List<Subject> GetSubjects { get; set; } = new();
        public List<Faculty> GetFaculties { get; set; } = new();

        public async Task OnGetAsync(int Id)
        {
            await getCourses();
            await getsubjects();
            await getFaculty();
            Batches = await _MasterService.GetBatches();
            BatchSubjects = await _MasterService.GetBatchSubjects();
            if(Id>0)
            {
                var batchData = Batches.Where(x => x.Id == Id).FirstOrDefault();
                var batchSubject= BatchSubjects.Where(x=>x.Id==Id).FirstOrDefault();
                if (batchData != null && batchSubject!=null)
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

                    BatchSubject.UpdatedBy=batchSubject.UpdatedBy;
                    BatchSubject.UpdatedDate = batchSubject.UpdatedDate;
                    BatchSubject.CreatedDate=batchSubject.CreatedDate;
                    BatchSubject.CreatedDate = batchSubject.CreatedDate;
                    BatchSubject.SubjectId = batchSubject.SubjectId;
                    BatchSubject.FacultyId = batchSubject.FacultyId;
                    BatchSubject.StartTiming = batchSubject.StartTiming;
                    BatchSubject.EndTiming = batchSubject.EndTiming;


                }
                value = "Update";
            }
        }
        public async Task getCourses()
        {
            var coursesList = await _MasterService.GetCourse();
            GetCourses = coursesList.ToList();
        }
        public async Task getsubjects()
        {
            var subjectsList = await _MasterService.GetSubjects();
            GetSubjects = subjectsList.Where(s => s.IsActive == true).ToList();
        }
        public async Task getFaculty()
        {
            var facultyList = await _MasterService.GetFaculties();
            GetFaculties= facultyList.ToList();
        }
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    var user = _UserManager.GetUserId(User);
        //    userId = user;
        //    if (Batch.Id == 0 && BatchSubject.Id==0)
        //    {
        //        Batch.CreatedBy=_UserManager.GetUserId(User);   
        //        Batch.CreatedDate=DateTime.Now;
        //        BatchSubject.CreatedBy  =_UserManager.GetUserId(User);
        //        BatchSubject.CreatedDate = DateTime.Now;
        //        var data1= await _MasterService.InsertBatchSubjects(BatchSubject);
        //        var data = await _MasterService.InsertBatch(Batch);
        //        if (data.Succeeded && data1.Succeeded)
        //        {
        //            _notyf.Success(data.Messages[0]);
        //        }
        //        else
        //        {
        //            _notyf.Error(data.Messages[0]);
        //        }
        //    }
        //    else
        //    {
        //        Batch.UpdatedDate=DateTime.Now;
        //        Batch.UpdatedBy = _UserManager.GetUserId(User);
        //        var data= await _MasterService.UpdateBatch(Batch);
        //        BatchSubject.UpdatedBy = _UserManager.GetUserId(User);
        //        BatchSubject.UpdatedDate = DateTime.Now;
        //        var data1 = await _MasterService.UpdateBatchSubjects(BatchSubject);
        //        if (data.Succeeded && data1.Succeeded)
        //        {
        //            _notyf.Success(data.Messages[0]);
        //        }
        //        else
        //        {
        //            _notyf.Error(data.Messages[0]);
        //        }
        //    }
        //    return Redirect("Batch");
        //}
        //public async Task<IActionResult> OnPostDelete(int Id)
        //{
        //    var data = await _MasterService.DeleteBatch(Id);
        //    var data1=await _MasterService.DeleteBatchSubject(Id);
        //    if (data.Succeeded && data.Succeeded)
        //    {
        //        _notyf.Success(data.Messages[0]);
        //    }
        //    else
        //    {
        //        _notyf.Error(data.Messages[0]);
        //    }
        //    return Redirect("Batch");
        //}
  
    }
}
