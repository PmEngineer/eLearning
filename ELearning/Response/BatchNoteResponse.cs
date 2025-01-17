using ELearning_Core.Model.Faculty;
using ELearning_Core.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Response
{
    public class BatchNoteResponse
    {
        public String Notes { get; set; }
        public int BatchId { get; set; }
        
        public int SubjectId { get; set; }
    }
}
