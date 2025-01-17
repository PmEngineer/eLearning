using AutoMapper;

namespace ELearning.Profiles
{
    public class BatchClassProfile:Profile
    {
        public BatchClassProfile()
        {
            CreateMap<ELearning_Core.Model.Faculty.BatchClass, ELearning.Response.BatchClassResponse>().ReverseMap();
        }
    }
}
