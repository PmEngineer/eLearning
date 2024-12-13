using ELearning_Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Core.Model.Master
{
    public class Licence : BaseEntity
    {
        public string LicenceKey { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company company { get; set; }

    }
}
