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
using Microsoft.AspNetCore.Identity;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Identity.UI.Services;
using Org.BouncyCastle.Crypto.Generators;
using ELearning_Core.Model.MailSettings;
using static System.Net.WebRequestMethods;

namespace ELearning.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public IStudentServiceAPI _studentService { get; set; }
        private UserManager<IdentityUser> _userManager;
        public readonly IMailService _mailService;

        public StudentController(IStudentServiceAPI studentService, UserManager<IdentityUser> userManager, IMailService mailService)
        {
            _studentService = studentService;
            _userManager = userManager;
            _mailService = mailService;

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
        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(PasswordRequest model)
        {
            if (string.IsNullOrEmpty(model.Email))
                return BadRequest("Email is required.");

            var user = await _studentService.FindByEmailAsync(model);
            if (user == null)
                return BadRequest("User not found.");

            // Generate OTP
            var otp = new Random().Next(1000, 9999).ToString();

            // Store OTP and expiry in the database
            user.OTP = otp;
            user.OtpExpiryTime = DateTime.UtcNow.AddMinutes(5); 
            await _studentService.UpdateStudentInfoPassword(user);

            // Send OTP via Email
            try
            {
                MailRequest request = new MailRequest();
                request.Subject = "Login";
                request.ToEmail = user.Email;
                request.Body = "<table ><tr><b> <td>Email :" + user.Email + "</td></b> <td></td></tr> <tr> <b> <td>OTP:" + otp + "</td></b><td></td> </tr> </table> ";


                await _mailService.SendEmailAsync(request);
            }
            catch(Exception ex)
            {
           
                return Ok(" email Failed");
            }
          

            return Ok("OTP sent  to your email.");
        }
        [HttpPost]
        [Route("VerifyOtp")]
        public async Task<IActionResult> VerifyOtp(PasswordRequest model)
        {
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Otp))
                return BadRequest("Email and OTP are required.");

            var user = await _studentService.FindByEmailAsync(model);
            if (user == null)
                return BadRequest("User not found.");

            if (user.OTP != model.Otp || user.OtpExpiryTime < DateTime.UtcNow)
                return BadRequest("Invalid or expired OTP.");

            // OTP is valid, send current password to the user's email
            MailRequest request = new MailRequest();
            request.Subject = "Login";
            request.ToEmail = user.Email;
            request.Body = "  <table ><tr><b> <td>Email :" + user.Email + "</td></b> <td></td></tr> <tr> <b> <td>Password:" + user.Password + "</td></b><td></td> </tr> </table> ";

            await _mailService.SendEmailAsync(request);
            

            return Ok("OTP verified and password sent to your email.");
        }
        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(PasswordRequest passwordRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Find the user
            var user = await _studentService.FindByEmailAsync(passwordRequest);
            if (user == null)
                return NotFound("User not found");

            // Validate current password
            if (user.Password != passwordRequest.CurrentPassword)
                return BadRequest("Current password is incorrect");

            // Hash new password and update user
            user.Password = passwordRequest.NewPassword;
            user.ConfirmPassword = passwordRequest.NewPassword;
            var data =  _studentService.UpdateStudentInfoPassword(user);
          

            return Ok(new { message = "Password changed successfully" });
        }

    }
}
