using ELearning_Core.Model.Quiz;
using ELearning_Core.Model.Student;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace ELearning.Request
{
    public class QuizAnswerRequest
    {
        public int QuestionId { get; set; }
        public int StudentId { get; set; }
        public int? OptionId { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionType { get; set; }
        public string? Answer { get; set; }
        public int Marks { get; set; }
        public String CreatedBy { get; set; }
    }
}
