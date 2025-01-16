using AutoMapper;
using ELearning.Response;
using ELearning_Core.Model.Master;

namespace ELearning.Profiles
{
    public class HelpDesk_ResponseProfile:Profile
    {
        public HelpDesk_ResponseProfile()
        {
            CreateMap<ELearning_Core.Model.Master.HelpDesk, ELearning.Response.HelpDesk_Response>()
                .ForMember(dest => dest.CreatedDate,
                           opt => opt.MapFrom(src => src.CreatedDate))
                .ReverseMap();
        }
    }
}
