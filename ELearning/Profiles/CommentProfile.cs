
using AutoMapper;
using ELearning.Controllers;
using ELearning.Request;
using ELearning_Core.Model.Master;

namespace ELearning.Profiles
{
    public class CommentProfile:Profile
    {
        public CommentProfile()
        {
            //CreateMap<ELearning_Core.Model.Master.DoubtComment, ELearning.Request.CommentResponse>().ReverseMap();
            CreateMap<ELearning_Core.Model.Master.Doubt, ELearning.Request.CommentRequest>().ReverseMap();

        }
    }
}
