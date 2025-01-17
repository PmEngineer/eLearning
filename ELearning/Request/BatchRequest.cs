namespace ELearning.Request
{
    public class BatchRequest
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public string Validity { get; set; }
        public bool IsPaid { get; set; }
        public decimal BatchFee { get; set; }
        public decimal? Discount { get; set; }
        public string CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

        public List<BatchSubjectRequest> BatchSubjects { get; set; }

    }
}
