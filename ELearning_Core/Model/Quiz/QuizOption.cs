using ELearning_Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Core.Model.Quiz
{
    public class QuizOption : BaseEntity
    {
        public int BatchQuizId { get; set; }
        [ForeignKey("BatchQuizId")]
        public virtual BatchQuiz BatchQuiz { get; set; }
        public string Eoption { get; set; }
        public string Hoption { get; set; }
        public bool IsCorrect{get;set;}
    }
}
