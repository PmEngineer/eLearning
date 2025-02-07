using ELearning_Core.Model.Quiz;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Request
{
    public class QuizOptionRequest
    {
        public int BatchQuizId { get; set; }
        public string Eoption { get; set; }
        public string Hoption { get; set; }
        public bool IsCorrect { get; set; }
    }
}
