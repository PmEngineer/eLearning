using AutoMapper;

namespace ELearning.Profiles
{
    public class BatchSubjectProfile:Profile
    {
        public BatchSubjectProfile()
        {
            CreateMap<ELearning_Core.Model.Faculty.BatchSubject,ELearning.Response.BatchSubjectResponse>().ReverseMap();
        }
    }
}
