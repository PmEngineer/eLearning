using AspNetCoreHero.ToastNotification.Abstractions;
using ELearning.Interface;
using ELearning.Services;
using ELearning_Core.Model;
using ELearning_Core.Model.Faculty;
using ELearning_Core.Model.Quiz;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ELearning.Pages.Master
{
    public class BatchQuizModel : PageModel
    {
        public readonly IMasterService _MasterService;
      public readonly IBatchService _BatchService;
        private readonly INotyfService _notyf;
        private readonly UserManager<IdentityUser> _UserManager;
        public BatchQuizModel(IBatchService batchService,INotyfService notfy,UserManager<IdentityUser> userManager, IMasterService MasterService)
        {
            _BatchService = batchService;
            _notyf = notfy;
            _UserManager = userManager;
            _MasterService = MasterService;
        }
        [Parameter]
        public int Id { get; set; } 
        public string userId {  get; set; }
        public string value { get; set; } = "Save";
        [BindProperty]
        public BatchQuiz BatchQuiz { get; set; } = new();
        public List<BatchQuiz> BatchQuizzes { get; set; } = new();
        public List<Subject> GetSubjects { get; set; } = new(); 
        public List<Batch> GetBatches { get; set; } = new();

        public async Task OnGetAsync(int Id)
        {
            await getSubjects();
            await getBatches();
            BatchQuizzes = await _BatchService.GetQuizzes();
            if (Id>0)
            {
                var quizData = BatchQuizzes.Where(x => x.Id == Id).FirstOrDefault();
                if (quizData != null)
                {
                    BatchQuiz.Id = quizData.Id;
                    BatchQuiz.SubjectId = quizData.SubjectId;
                    BatchQuiz.BatchId = quizData.BatchId;
                    BatchQuiz.HQuestions = quizData.HQuestions;
                    BatchQuiz.Questions = quizData.Questions;
                    BatchQuiz.QuestionType = quizData.QuestionType;
                    BatchQuiz.CreatedBy = quizData.CreatedBy;
                    BatchQuiz.UpdatedBy = quizData.UpdatedBy;
                    BatchQuiz.CreatedDate = quizData.CreatedDate;
                    BatchQuiz.UpdatedDate = quizData.UpdatedDate;
                }

                value = "Update";
            }
        }

        public async Task getSubjects()
        {
            var subjectList = await _MasterService.GetSubjects();
            GetSubjects = subjectList.Where(x => x.IsActive == true).ToList();
        }
        public async Task getBatches()
        {
            var batchList = await _MasterService.GetBatches();
            GetBatches = batchList.ToList();
        }
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    {
        //        var user = _UserManager.GetUserId(User);
        //        userId = user;
        //        if(BatchQuiz.Id==0)
        //        {
        //            BatchQuiz.CreatedDate=DateTime.Now;
        //            BatchQuiz.CreatedBy = user;
        //            var data= await _BatchService.InsertQuiz(BatchQuiz);
        //            if (data.Succeeded)
        //            {
        //                _notyf.Success(data.Messages[0]);
        //            }
        //            else
        //            {
        //                _notyf.Error(data.Messages[0]);
        //            }
        //        }
        //        else
        //        {
        //            BatchQuiz.UpdatedDate = DateTime.Now;
        //            BatchQuiz.UpdatedBy = user;
        //            var data = await _BatchService.UpdateQuiz(BatchQuiz);
        //            if (data.Succeeded)
        //            {
        //                _notyf.Success(data.Messages[0]);
        //            }
        //            else
        //            {
        //                _notyf.Error(data.Messages[0]);
        //            }
        //        }
        //    }
        //    return Redirect("BatchQuiz");
        //}
        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var data= await _BatchService.DeleteQuiz(Id);
            if (data.Succeeded)
            {
                _notyf.Success(data.Messages[0]);
            }
            else
            {
                _notyf.Error(data.Messages[0]);
            }
            return Redirect("BatchQuiz");
        }
    }
}
