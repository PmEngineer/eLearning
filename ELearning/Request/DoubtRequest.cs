namespace ELearning.Request
{
    public class DoubtRequest
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }

        public string Description { get; set; }
        public string Solution { get; set; }
        public string CreatedBY { get; set; }
        
    }
}

