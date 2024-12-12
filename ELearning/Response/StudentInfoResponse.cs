using ELearning_Core.Model;

namespace ELearning.Response
{
    public class StudentInfoResponse
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
      
        public int CompanyId { get; set; }
        public string? OTP { get; set; }


    }
}
