using ELearning_Core.Model.Faculty;
using ELearning_Core.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Response
{
    public class BatchQuizResponse
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public int BatchId { get; set; }
        public string BatchName{get;set;}
        public string SubjectName { get; set; }
        public string Questions { get; set; }
        public string HQuestions { get; set; }
        public int QuestionType { get; set; }
    public List<QuizOptionResponse> QuizOption { get; set; }
    }
}
