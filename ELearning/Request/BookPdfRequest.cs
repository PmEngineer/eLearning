namespace ELearning.Request
{
    public class BookPdfRequest
    {
        public int CourseId {  get; set; }
        public int SubjectId {  get; set; }
        public string BookName { get; set; }
        public bool IsPaid {  get; set; }
        public string BookPdfFile {  get; set; }
    }
}
