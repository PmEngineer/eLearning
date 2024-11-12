using ELearning_Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Core.Model.Master
{
   public class DoubtLike:BaseEntity
    {
        public int DoubtId {  get; set; }
        [ForeignKey("DoubtId")]

        public int isLike {  get; set; }
    }
}
