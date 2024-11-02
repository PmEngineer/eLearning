using AutoMapper;

namespace ELearning.Profiles
{
    public class DoubtRequestProfile:Profile
    {
        public DoubtRequestProfile()
        {
            CreateMap<ELearning_Core.Model.Master.Doubt,ELearning.Request.DoubtRequest>().ReverseMap();
        }
    }
}
