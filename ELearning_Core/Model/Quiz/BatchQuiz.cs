using ELearning_Core.Model.Faculty;
using ELearning_Core.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearning_Core.Model.Quiz
{
    public class BatchQuiz:BaseEntity
    { 
        public int SubjectId {  get; set; }
        [ForeignKey("SubjectId")]
        public virtual Subject Subject { get; set; }    
        public int BatchId {  get; set; }
        [ForeignKey("BatchId")]
        public virtual Batch Batch { get; set; }    
        public string Questions { get; set; }
        public string HQuestions { get; set; }
        public int QuestionType { get; set; }

    }
}
