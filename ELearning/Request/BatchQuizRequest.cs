using ELearning_Core.Model.Faculty;
using ELearning_Core.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Request
{
    public class BatchQuizRequest
    {
        public int SubjectId { get; set; }
        public int BatchId { get; set; }
        public string Questions { get; set; }
        public string HQuestions { get; set; }
        public int QuestionType { get; set; }
        public string CreatedBy { get; set; }
        public List<QuizOptionRequest> QuizOptions { get; set; }
    }
}
