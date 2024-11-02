using ELearning_Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Core.Model.Master
{
    public class Doubt: BaseEntity
    {
        public int SubjectId {  get; set; }
        [ForeignKey("SubjectId")]
        public virtual Subject? Subject { get; set; } 
        public string? Description { get; set; }
        public int Filetype {  get; set; }
        public string? Solution { get; set; }
        public int TotalComment {  get; set; }
        public int TotalLike { get; set; }
        public bool IsActive { get; set; }
    }
}
