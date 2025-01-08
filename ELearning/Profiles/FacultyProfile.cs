using AutoMapper;

namespace ELearning.Profiles
{
    public class FacultyProfile:Profile
    {
        public FacultyProfile()
        {
            CreateMap<ELearning_Core.Model.Faculty.Faculty,ELearning.Response.FacultyResponse>().ReverseMap();
        }
    }
}
