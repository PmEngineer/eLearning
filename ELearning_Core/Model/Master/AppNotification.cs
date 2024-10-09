using System.ComponentModel.DataAnnotations;
using ELearning_Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Core.Model.Master
{
    public class AppNotification: BaseEntity
    {

        [Required]
        [StringLength(250)]
        public string Subject { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public bool IsActive { get; set; }

    }
}
