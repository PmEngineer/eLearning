using ELearning_Core.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Request
{
    public class StudentInfoRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int CompanyId { get; set; }
        public string? CreatedBY { get; set; }
        public string? UpdatedBY { get; set; }

    }
}
