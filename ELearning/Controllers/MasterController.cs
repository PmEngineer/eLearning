using ELearning.API;
using ELearning.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetSubject()
        {
            var data = await _masterService.GetSubjectsList();

            return Ok(data);
        }
    }
}
