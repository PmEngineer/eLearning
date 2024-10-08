using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELearning_Core.Shared;

namespace ELearning_Core.Model
{
    public class Lessons : BaseEntity
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(150)]
        public string HindiName { get; set; }

        public string Description { get; set; }
        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }
       public bool IsActive { get; set; }

    }
}
