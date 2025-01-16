using AutoMapper;

namespace ELearning.Profiles
{
    public class BatchRequestProfile:Profile
    {
        public BatchRequestProfile()
        {
            CreateMap<ELearning_Core.Model.Faculty.Batch,ELearning.Request.BatchRequest>().ReverseMap();
            CreateMap<ELearning_Core.Model.Faculty.BatchSubject,ELearning.Request.BatchSubjectRequest>().ReverseMap();
        }
    }
}
