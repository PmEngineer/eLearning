using System.ComponentModel.DataAnnotations;
using ELearning_Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning_Core.Model.Master
{
    public class AppNotification : BaseEntity
    {

        [Required]
        public int SubjectId { get; set; }
        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }
        public string Description { get; set; }

        public string Image { get; set; }

        public bool IsActive { get; set; }

    }
}
