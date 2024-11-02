using ELearning_Core.Model;

namespace ELearning.Response
{
    public class DoubtResponse
    { 
        public int id { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject? Subject { get; set; }

        public string? Description { get; set; }
        public int Filetype { get; set; }
        public string? Solution { get; set; }
        public int TotalComment { get; set; }
        public int TotalLike { get; set; }

    }
}
