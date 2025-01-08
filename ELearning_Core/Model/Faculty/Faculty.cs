using ELearning_Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Core.Model.Faculty
{
    public class Faculty:BaseEntity
    {
        [Required]
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        [MaxLength(10)]
        public string Contact { get; set; }
        public string Address { get; set; }
        public string Qualification { get; set; }
        public string Image { get; set; }


    }
}
