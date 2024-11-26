using ELearning_Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Core.Model.Master
{
    public class PreviousYearPaper:BaseEntity
    {
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
        public string NoteName { get; set; }
        public bool IsPaid { get; set; }

        public int Year { get; set; }
        public string Paperpdf { get; set; } 

    }
}
