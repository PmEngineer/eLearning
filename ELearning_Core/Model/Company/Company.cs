
using ELearning_Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Core.Model
{
    public  class Company : BaseEntity
    {

        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string EmailId { get; set; }

        public string? GSTNo { get; set; }
        public bool IsActive { get; set; }

    }
}
