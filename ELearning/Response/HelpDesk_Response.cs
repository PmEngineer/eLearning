namespace ELearning.Response
{
    public class HelpDesk_Response
    {
        public int Id { get; set; }
        public int StudentId { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string ProblemDescription { get; set; }
        public bool Status { get; set; }

        public DateTime? SolvedDate { get; set; }
        public string? UpdatedBY { get; set; }
        public string? CreatedBY { get; set; }

        public DateTime CreatedDate { get; set; }
        public CategoryResponse CategoryResponse { get; set; }
        public SubcategoryResponse SubcategoryResponse { get; set; }
    }
}
