using ELearning_Core.Model.Master;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Request
{
    public class DoubtLikeRequest
    {
        public int DoubtId { get; set; }
       public virtual Doubt? Doubt {  get; set; } 

        public int isLike { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }


    }
}
