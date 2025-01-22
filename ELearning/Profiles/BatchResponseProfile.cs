using AutoMapper;

namespace ELearning.Profiles
{
    public class BatchResponseProfile : Profile
    {
        public BatchResponseProfile()
        {
            CreateMap<ELearning_Core.Model.Faculty.Batch, ELearning.Response.BatchResponse>()
                 .ForMember(dest => dest.Name,
                           opt => opt.MapFrom(src => src.Name)).ReverseMap()
                            .ForMember(dest => dest.Syllabus,
                           opt => opt.MapFrom(src => src.Syllabus)).ReverseMap();
            CreateMap<ELearning_Core.Model.Faculty.BatchSubject, ELearning.Response.BatchSubjectResponse>().ReverseMap();
        }

    }
}
