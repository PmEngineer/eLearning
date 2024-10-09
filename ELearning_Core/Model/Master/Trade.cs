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
    public class Trade : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name {  get; set; }
        [Required]
        [StringLength(50)]
        public bool IsActive { get; set; }
            
    }
}
