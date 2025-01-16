using ELearning_Core.Model.Master;
using ELearning_Core.Model.Student;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Request
{
    public class HelpDesk_Request
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
     
        public int CategoryId { get; set; }
        //public string CategoryName { get; set; }
        public int SubCategoryId { get; set; }
        //public string SubCategoryName { get; set; }
        public string ProblemDescription { get; set; }
        public bool Status { get; set; }

        public DateTime? SolvedDate { get; set; }
        public string? CreatedBY { get; set; }
        public string? UpdatedBY { get; set; }
    }
}
