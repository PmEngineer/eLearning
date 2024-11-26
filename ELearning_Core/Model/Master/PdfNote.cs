using ELearning_Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Core.Model.Master
{
    public class PdfNote:BaseEntity
    {
        public int CourseId { get; set; }
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
        public string NoteName {  get; set; }
        public bool IsPaid { get; set; }

        public string PdfFile { get; set; }
    }
}
