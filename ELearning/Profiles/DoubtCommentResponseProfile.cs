using AutoMapper;

namespace ELearning.Profiles
{
    public class DoubtCommentResponseProfile:Profile
    {
     public DoubtCommentResponseProfile()
        {
            CreateMap<ELearning_Core.Model.Master.DoubtComment, ELearning.Response.DoubtCommentResponse>().ReverseMap();
        }   
    }
}
