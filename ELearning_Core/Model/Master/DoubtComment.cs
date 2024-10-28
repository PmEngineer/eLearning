using ELearning_Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Core.Model.Master
{
    public class DoubtComment:BaseEntity
    {

        public int DoubtId {  get; set; }
        [ForeignKey("DoubtId")]

        public virtual Doubt? Doubt { get; set; }
        public string Comment { get; set; }

        public bool IsActive {  get; set; }

    }
}
