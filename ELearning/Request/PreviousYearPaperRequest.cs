namespace ELearning.Request
{
    public class PreviousYearPaperRequest
    {
        public int CourseId { get; set; }
        public string NoteName { get; set; }
        public bool IsPaid { get; set; }

        public int Year { get; set; }
        public string Paperpdf { get; set; }
    }
}
