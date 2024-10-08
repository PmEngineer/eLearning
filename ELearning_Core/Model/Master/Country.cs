using ELearning_Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Core.Model.Master
{
    public class Country : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
