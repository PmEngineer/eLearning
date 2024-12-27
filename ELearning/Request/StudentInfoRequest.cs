using ELearning_Core.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Request
{
    public class StudentInfoRequest
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int CompanyId { get; set; }
        public string? CreatedBY { get; set; }
        public string? UpdatedBY { get; set; }
        public string? OTP { get; set; }
        public DateTime? OtpExpiryTime { get; set; }
        

    }
}
