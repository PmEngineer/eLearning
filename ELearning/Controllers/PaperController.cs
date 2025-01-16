using ELearning.Request;
using ELearning_Core.Procedure;
using Microsoft.AspNetCore.Mvc;

namespace ELearning.Controllers
{
    public class PaperController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> GetLessonBySubject(int SubId)
        {
            GetLessonsBySubject obj = new GetLessonsBySubject();
            var data = obj.getLessonsBySubject(SubId);
            return Json("");
        }
    }

}
