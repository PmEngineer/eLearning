using ELearning_Core.Model;

namespace ELearning.Response
{
    public class BatchSubjectResponse
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public string FacultyName{ get; set; }
        public string SubjectName { get; set; }
        public int FacultyId { get; set; }
        public DateTime? StartTiming { get; set; }
        public DateTime? EndTiming { get; set; }
        public string CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
