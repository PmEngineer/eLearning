using ELearning_Core.Model.Master;

namespace ELearning.Request
{
    public class DoubtCommentRequest
    {
        public int Id { get; set; }
        public int DoubtId { get; set; }
        public virtual Doubt? Doubt { get; set; }
        public string Comment { get; set; }
        public string UpdatedBy { get; set; }
    }
}
