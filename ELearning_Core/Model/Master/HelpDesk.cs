using ELearning_Core.Model.Student;
using ELearning_Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Core.Model.Master
{
    public class HelpDesk : BaseEntity
    {
       
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual StudentInfo? StudentInfo { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
        public int SubCategoryId { get; set; }
        [ForeignKey("SubCategoryId")]
        public virtual SubCategory? SubCategory { get; set; }
        public string ProblemDescription { get; set; }
        public bool Status { get; set; }
        
        public DateTime? SolvedDate { get; set; }
     
    }
}
