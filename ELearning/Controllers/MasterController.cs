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

        public MasterController(IMasterServiceAPI masterService)
        {
            _masterService = masterService;

        }
        [HttpGet]
        [Route("GetSubject")]
        public async Task<IActionResult> GetSubject()
        {
            var data = await _masterService.GetSubjectsList();

            return Ok(data);
        }
        [HttpGet]
        [Route("GetCourseList")]
        public async Task<IActionResult> GetCourseList()
        {
            var data = await _masterService.GetCourseList();
            return Ok(data);
        }

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

        #region
        [HttpGet]
        [Route("GetPdfNotes")]
        public async Task<IActionResult> GetPdfNotes(int Id)
        {
            var data = await _masterService.GetPdfNotes(Id);
            return Ok(data);    
        }

        #endregion


        #region
        [HttpGet]
        [Route("GetPapersPdf")]
        public async Task<IActionResult> GetPapersPdf(int Id)
        {
            var data = await _masterService.GetPapersPdf(Id);
            return Ok(data);
        }

        #endregion
    }
}
