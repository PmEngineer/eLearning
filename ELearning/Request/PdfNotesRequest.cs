using ELearning_Core.Model.Master;
using System.ComponentModel.DataAnnotations.Schema;

namespace ELearning.Request
{
    public class PdfNotesRequest
    {
        public int CourseId { get; set; }
            public string NoteName { get; set; }
        public bool IsPaid { get; set; }

        public string PdfFile { get; set; } 
    }
}
