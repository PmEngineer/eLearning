using AutoMapper;

namespace ELearning.Profiles
{
    public class DoubtLikeProfile:Profile
    {
        public DoubtLikeProfile() 
        { 
            CreateMap< ELearning_Core.Model.Master.DoubtLike,ELearning.Request.DoubtLikeRequest>().ReverseMap();
        }
    }
}
