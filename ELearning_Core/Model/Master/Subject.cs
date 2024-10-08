using ELearning_Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Core.Model
{
    public class Subject : BaseEntity
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(150)]
        public string HindiName { get; set; }

        public bool IsActive { get; set; }
    }
}
