using ELearning.API;
using ELearning.Interface;
using ELearning_Core.Model.Master;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ELearning.Response;
using ELearning.Request;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ELearning_Core.Shared;

namespace ELearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        public IMasterServiceAPI _masterService { get; set; }
        public IBatchServiceAPI _batchService { get; set; }

        public MasterController(IMasterServiceAPI masterService, IBatchServiceAPI batchService)
        {
            _masterService = masterService;
            _batchService = batchService;


        }
        #region Subject
        [HttpGet]
        [Route("GetSubject")]
        public async Task<IActionResult> GetSubject()
        {
            var data = await _masterService.GetSubjectsList();

            return Ok(data);
        }
        #endregion

        #region Course
        [HttpGet]
        [Route("GetCourseList")]
        public async Task<IActionResult> GetCourseList()
        {
            var data = await _masterService.GetCourseList();
            return Ok(data);
        }

        #endregion
       
        #region Doubt
        [HttpGet]
        [Route("GetDoubtList")]
        public async Task<IActionResult> GetDoubtList(int subjectId)
        {
            var data = await _masterService.GetDoubtsList(subjectId);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetDoubts")]
        public async Task<IActionResult> GetDoubts(string userName)
        {
            var data = await _masterService.GetDoubts(userName);
            return Ok(data);
        }

        [HttpPost]
        [Route("InsertDoubt")]
        public async Task<IActionResult> InsertDoubt(DoubtRequest doubt)
        {
            var data = await _masterService.InsertDoubt(doubt);
            return Ok(data);
        }

        [HttpPost]
        [Route("UpdateDoubt")]
        public async Task<IActionResult> UpdateDoubt(DoubtRequest doubt)
        {
            var data = await _masterService.UpdateDoubt(doubt);
            return Ok(data);
        }
        [HttpGet]
        [Route("DeleteDoubt")]
        public async Task<IActionResult> DeleteDoubt(int Id)
        {
            var data = await _masterService.DeleteDoubt(Id);
            return Ok(data);
        }

        [HttpGet]
        [Route("GetDoubtById")]
        public async Task<IActionResult> GetDoubtById(int Id)
        {
            var data = await _masterService.GetDoubtById(Id);
            return Ok(data);
        }
        #endregion

        #region DoubtComment
        [HttpGet]
        [Route("GetAllDoubtComment")]
        public async Task<IActionResult> GetAllDoubtComment(int Id)
        {
            var data = await _masterService.GetAllDoubtComment(Id);
            return Ok(data);
        }
        [HttpPost]
        [Route("InsertDoubtComment")]
        public async Task<IActionResult> InsertDoubtComment(DoubtCommentResponse doubtComment)
        {

            var data = await _masterService.InsertDoubtComment(doubtComment);
            return Ok(data);
        }
        //[HttpGet]
        //[Route("GetComment")]
        //public async Task<IActionResult> GetComment(int Id)
        //{
        //    var data = await _masterService.GetComment(Id);
        //    return Ok(data);
        //}

        [HttpPost]
        [Route("UpdateDoubtComment")]
        public async Task<IActionResult> UpdateDoubtComment(DoubtCommentRequest request)
        {
            var data = await _masterService.UpdateDoubtComment(request);
            return Ok(data);
        }
        [HttpGet]
        [Route("DeleteDoubtComment")]
        public async Task<IActionResult> DeleteDoubtComment(int Id)
        {
            var data = await _masterService.DeleteDoubtComment(Id);
            return Ok(data);
        }
        #endregion

        #region DoubtLike
        [HttpPost]
        [Route("IsLike")]
        public async Task<IActionResult> IsLike(DoubtLikeRequest doubtLike)
        {
            var data = await _masterService.IsLike(doubtLike);
            return Ok(data);
        }
        #endregion

        #region PdfNotes
        [HttpGet]
        [Route("GetPdfNotes")]
        public async Task<IActionResult> GetPdfNotes(int Id)
        {
            var data = await _masterService.GetPdfNotes(Id);
            return Ok(data);
        }

        #endregion

        #region PaperPdf
        [HttpGet]
        [Route("GetPapersPdf")]
        public async Task<IActionResult> GetPapersPdf(int Id)
        {
            var data = await _masterService.GetPapersPdf(Id);
            return Ok(data);
        }

        #endregion

        #region BookPdf
        [HttpGet]
        [Route("GetBooks")]
        public async Task<IActionResult> GetBooks(int Cid, int Sid)
        {
            var data = await _masterService.GetBooks(Cid, Sid);
            return Ok(data);
        }
        #endregion

        #region Faculty
        [HttpGet]
        [Route("GetFacultyList")]
        public async Task<IActionResult> GetFacultyList()
        {
            var data = await _masterService.GetFacultyList();
            return Ok(data);
        }
        #endregion

        #region Help Desk Response 
        [HttpGet]
        [Route("GetAllProblems")]
        public async Task<IActionResult> GetAllProblems()
        {
            var data = await _masterService.GetAllProblems();
            return Ok(data);
        }
        [HttpGet]
        [Route("GetProblemsByStdId")]
        public async Task<IActionResult> GetProblemsByStdId(int Id)
        {
            var data = await _masterService.GetProblemsByStdId(Id);
            return Ok(data);
        }
        #endregion

        #region Help Desk Request 
        [HttpPost]
        [Route("InsertProblems")]
        public async Task<IActionResult> InsertProblems(HelpDesk_Request helpDesk)
        {
            var data = await _masterService.InsertProblems(helpDesk);
            return Ok(data);
        }
        [HttpPost]
        [Route("Updateproblems")]
        public async Task<IActionResult> Updateproblems(HelpDesk_Request helpDesk)
        {
            var data = await _masterService.Updateproblems(helpDesk);
            return Ok(data);
        }
        #endregion

        #region Category
        [HttpGet]
        [Route("GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            var data = await _masterService.GetAllCategory();
            return Ok(data);
        }

        [HttpGet]
        [Route("GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(int Id)
        {
            var data = await _masterService.GetCategoryById(Id);
            return Ok(data);
        }
        #endregion

        #region SubCategory
        [HttpGet]
        [Route("GetAllSubCategory")]
        public async Task<IActionResult> GetAllSubCategory(int Id)
        {
            var data = await _masterService.GetAllSubCategory(Id);
            return Ok(data);
        }
        [HttpGet]
        [Route("GetSubCategoryById")]
        public async Task<IActionResult> GetSubCategoryById(int Cid, int Sid)
        {
            var data = await _masterService.GetSubCategoryById(Cid, Sid);
            return Ok(data);
        }
        #endregion

        #region BatchList

        [HttpGet]
        [Route("GetBatchById")]
        public async Task<IActionResult> GetBatchById(int Id,int type)
        {
            var data = await _masterService.GetBatchById(Id,type);
            return Ok(data);
        }
        #endregion

        #region BatchSubject
        [HttpGet]
        [Route("GetBatchSubject")]
        public async Task<IActionResult> GetBatchSubject(int Id)
        {
            var data=await _batchService.GetBatchSubject(Id);
            return Ok(data);    
        }
        #endregion

        #region Batchclass
        [HttpGet]
        [Route("GetBatchClass")]
        public async Task<IActionResult> GetBatchClass(int Bid, int Sid)
        {
            var data = await _batchService.GetBatchClass(Bid, Sid);
            return Ok(data);

        }
        #endregion

        #region BatchNote
        [HttpGet]
        [Route("GetBatchNotes")]
        public async Task<IActionResult> GetBatchNotes(int Bid, int Sid)
        {
            var data = await _batchService.GetBatchNotes(Bid,Sid);
            return Ok(data);

        }

        #endregion

        #region BatchQuiz
        [HttpGet]
        [Route("GetQuizResponses")]
        public async Task<IActionResult> GetQuizResponses(int Bid, int Sid)
        {
            var data=await _batchService.GetQuizResponses(Bid, Sid);
            return Ok(data);
        }
        #endregion
    }
}
