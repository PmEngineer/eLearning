using ELearning_Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Core.Model.Master
{
    public class SubCategory : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]

        public int CategoryId {  get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }

        public bool IsActive { get; set; }
    }
}
