using AutoMapper;

namespace ELearning.Profiles
{
    public class StudentInfoResponseProfile:Profile
    {
        public StudentInfoResponseProfile()
        {
            CreateMap<ELearning_Core.Model.Student.StudentInfo, ELearning.Response.StudentInfoResponse>().ReverseMap();
        }
    }
}
