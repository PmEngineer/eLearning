using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELearning_Core.Shared;


namespace ELearning_Core.Model.Master
{
    public class State : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }
        public int CountryId { get; set; }  
        [ForeignKey("CountryId")]
        public virtual Country? Country { get; set; }
        public bool IsActive { get; set; }
    }
}
