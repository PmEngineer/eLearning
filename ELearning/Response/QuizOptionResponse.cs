using ELearning_Core.Model.Faculty;
using ELearning_Core.Model;
using System.ComponentModel.DataAnnotations.Schema;
using ELearning_Core.Model.Quiz;

namespace ELearning.Response
{
    public class QuizOptionResponse
    {
        public int BatchQuizId { get; set; }
        public string Eoption { get; set; }
        public string Hoption { get; set; }
        public bool IsCorrect { get; set; }
        public int Id { get; set; }
    }
}
