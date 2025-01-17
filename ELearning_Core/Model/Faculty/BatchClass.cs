using ELearning_Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Core.Model.Faculty
{
    public class BatchClass:BaseEntity
    {
        public string ClassName { get; set; }
        public int BatchId { get; set; }
        [ForeignKey("BatchId")]
        public virtual Batch Batch { get; set; }
        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }
        public bool IsPaid { get; set; }
        public string YouTubeLink {  get; set; }
        public string Image { get; set; }
    }
}
