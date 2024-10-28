using ELearning.API;
using ELearning.Interface;
using ELearning_Core.Model.Master;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ELearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        public IMasterServiceAPI _masterService { get; set; }
        public MasterController(IMasterServiceAPI masterService) {
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

        [HttpGet]
        [Route("GetDoubtList")]
        public async Task<IActionResult> GetDoubtList() 
        {
            var data=await _masterService.GetDoubtsList();
            return Ok(data);
        }
        [HttpPost]
        [Route("InsertDoubt")]
        public async Task<IActionResult> InsertDoubt(Doubt doubt)
        {
            var data = await _masterService.InsertDoubt(doubt);
            return Ok(data);
        }
        [HttpGet]
        [Route("GetDoubtComment")]
        public async Task<IActionResult> GetDoubtComment()
        {
            var data= await _masterService.GetDoubtComment();
            return Ok(data);
        }
        [HttpPost]
        [Route("InsertDoubtComment")]
        public async Task<IActionResult> InsertDoubtComment(DoubtComment doubtComment)
        {
            var data = await _masterService.InsertDoubtComment(doubtComment);
            return Ok(data);
        }
    }
}
