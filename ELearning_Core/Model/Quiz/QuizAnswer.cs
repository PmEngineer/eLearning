using ELearning_Core.Model.Student;
using ELearning_Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Core.Model.Quiz
{
    public class QuizAnswer:BaseEntity
    {
        public int QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public virtual BatchQuiz BatchQuiz { get; set; }
        public int StudentId {  get; set; }
        [ForeignKey("StudentId")]
        public virtual StudentInfo StudentInfo { get; set; }    
        public int OptionId {  get; set; }
        public bool IsCorrect {  get; set; }
        public int QuestionType {  get; set; }
        public string? Answer {  get; set; }
        public int Marks { get; set; }
    }
}
