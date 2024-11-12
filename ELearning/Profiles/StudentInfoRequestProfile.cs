using AutoMapper;

namespace ELearning.Profiles
{
    public class StudentInfoRequestProfile:Profile
    {
        public StudentInfoRequestProfile()
        {
            CreateMap<ELearning_Core.Model.Student.StudentInfo, ELearning.Request.StudentInfoRequest>().ReverseMap();
        }
    }
}
