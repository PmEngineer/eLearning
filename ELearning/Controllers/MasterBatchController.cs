using ELearning.Interface;
using ELearning.Request;
using ELearning_Core.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.Controllers
{
    public class MasterBatchController : Controller
    {

        public IMasterService _masterService { get; set; }
        private readonly UserManager<IdentityUser> _userManger;
        public MasterBatchController(IMasterService masterService, UserManager<IdentityUser> userManger)
        {
            _masterService = masterService;
            _userManger = userManger;   
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> AddBatch(BatchRequest request)
        {
            var userID = _userManger.GetUserId(User);
            request.CreatedBy = userID;
            request.BatchSubjects.Select(x => { x.CreatedBy = userID; return x; }).ToList();   
            

            var data = await _masterService.InsertBatch(request);
            return Json(new { message = "Batch added successfully" });
        }
        
        
    }
}
