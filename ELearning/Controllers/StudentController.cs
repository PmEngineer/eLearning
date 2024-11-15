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

namespace ELearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public IStudentServiceAPI _studentService { get; set; }

        public StudentController(IStudentServiceAPI studentService)
        {
            _studentService = studentService;

        }
        [HttpPost]
        [Route("InsertStudentInfo")]
        public async Task<IActionResult> InsertStudentInfo(StudentInfoRequest studentInfoRequest)
        {

            var data = await _studentService.InsertStudentInfo(studentInfoRequest);
            return Ok(data);
        }
        [HttpPost]
        [Route("StudentLogin")]
        public async Task<IActionResult> StudentLogin(StudentLoginRequest studentLoginRequest)
        {
            var data = await _studentService.GetStudentByNameAndPassword(studentLoginRequest);
            return Ok(data);
        }
    }
}
