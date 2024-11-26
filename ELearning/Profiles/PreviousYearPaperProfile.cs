using AutoMapper;

namespace ELearning.Profiles
{
    public class PreviousYearPaperProfile : Profile
    {
        public PreviousYearPaperProfile()
        {
            CreateMap<ELearning_Core.Model.Master.PreviousYearPaper, ELearning.Request.PreviousYearPaperRequest>().ReverseMap();
        }
    }
}
