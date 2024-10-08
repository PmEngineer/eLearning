using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELearning_Core.Shared;
using ELearning_Core.Model.Master;

namespace ELearning_Core.Model.City
{
    public class City : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }
        public int StateId { get; set; }
        [ForeignKey("StateId")]
        public virtual State ? State { get; set; }
        public bool IsActive { get; set; }

    }
}
