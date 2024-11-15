using AutoMapper;

namespace ELearning.Profiles
{
    public class StudentLoginRequestProfile: Profile
    {
        public StudentLoginRequestProfile()
        {
            CreateMap<ELearning_Core.Model.Student.StudentInfo, ELearning.Request.StudentLoginRequest>().ReverseMap();
        }
    }
}
