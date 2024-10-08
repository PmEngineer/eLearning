using ELearning_Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Core.Model.Master
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public string Discription { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Validity { get; set; }
        public string? Support { get; set; }
        public string? Rating { get; set; }
        public string? Fee { get; set; }
        public string? Image { get; set; }
        public bool ISPaid { get; set; }
        public bool ISLive { get; set; }
        
    }
}
