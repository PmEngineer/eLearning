using ELearning_Core.Model.Faculty;

namespace ELearning.Request
{
    public class BatchSubjectRequest
    {
        public int Id {  get; set; }
        public int SubjectId { get; set; }
        public int FacultyId { get; set; }
        public DateTime? StartTiming { get; set; }
        public DateTime? EndTiming { get; set; }
        public string CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
