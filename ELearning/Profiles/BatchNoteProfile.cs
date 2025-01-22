using AutoMapper;

namespace ELearning.Profiles
{
    public class BatchNoteProfile:Profile
    {
        public BatchNoteProfile()
        {
            CreateMap<ELearning_Core.Model.Faculty.BatchNote, ELearning.Response.BatchNoteResponse>().ReverseMap();
        }
    }
}
