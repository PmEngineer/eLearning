using AutoMapper;

namespace ELearning.Profiles
{
    public class PdfNotesProfile:Profile
    {

        public PdfNotesProfile() 
        {
            CreateMap<ELearning_Core.Model.Master.PdfNote, ELearning.Request.PdfNotesRequest>().ReverseMap();
        }
    }
}
