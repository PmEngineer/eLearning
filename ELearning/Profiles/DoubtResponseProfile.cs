using AutoMapper;

namespace ELearning.Profiles
{
    public class DoubtResponseProfile:Profile
    {
        public DoubtResponseProfile()
        {
            CreateMap<ELearning_Core.Model.Master.Doubt, ELearning.Response.DoubtResponse>().ReverseMap();
        }
    }
}
