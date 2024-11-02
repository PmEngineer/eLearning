using ELearning_Core.Model.Master;

namespace ELearning.Response
{
    public class DoubtCommentResponse
    {
        public int DoubtId { get; set; }
        public virtual Doubt? Doubt { get; set; }
        public string Comment { get; set; }
        public string CreatedBy { get; set; }
    }
}
