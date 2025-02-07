 using ELearning.Interface;
using ELearning.Migrations;
using ELearning.Request;
using ELearning.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.Controllers
{
    public class MasterBatchController : Controller
    {

        public IMasterService _masterService { get; set; }
        public IBatchService _batchService { get; set; }
        private readonly UserManager<IdentityUser> _userManger;
        public MasterBatchController(IMasterService masterService, UserManager<IdentityUser> userManger, IBatchService batchService)
        {
            _masterService = masterService;
            _batchService= batchService;
            _userManger = userManger;   
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> AddBatch([FromForm] BatchRequest request)
        {
            var userID = _userManger.GetUserId(User);
            request.CreatedBy = userID;


           
            if (request.SyllabusPath != null && request.SyllabusPath.Length > 0)
            {
                var fileName = Path.GetFileName(request.SyllabusPath.FileName);
                var filePath = Path.Combine("wwwroot", "BatchFiles", fileName);

                var directoryPath = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await request.SyllabusPath.CopyToAsync(stream);
                }

               
                request.SyllabusFile = fileName; 
            }

            await _masterService.InsertBatch(request);
            return Json(new { message = "Batch added successfully" });
        }
        [HttpPost]
        public async Task<JsonResult> AddBatchQuiz([FromForm] BatchQuizRequest request)
        {
            var userID=_userManger.GetUserId(User);
            request.CreatedBy = userID;

            await _batchService.InsertQuiz(request);

            return Json(new { message = "Quiz Question added successfully" });
         }

    }
}
