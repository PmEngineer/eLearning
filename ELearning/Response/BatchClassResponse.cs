namespace ELearning.Response
{
    public class BatchClassResponse
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public int BatchId { get; set; }
        public string BatchName { get; set; }
        public string SubjectName { get; set; }
        public int SubjectId { get; set; }
        public string YouTubeLink { get; set; }
        public string Image { get; set; }
        public bool IsPaid { get; set; }
    }
}
