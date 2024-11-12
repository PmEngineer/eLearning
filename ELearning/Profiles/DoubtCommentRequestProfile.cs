using AutoMapper;
namespace ELearning.Profiles
{
    public class DoubtCommentRequestProfile:Profile
    {
        public DoubtCommentRequestProfile()
        {

            CreateMap<ELearning_Core.Model.Master.DoubtComment,ELearning.Request.DoubtCommentRequest>().ReverseMap();
        }
    }
}
