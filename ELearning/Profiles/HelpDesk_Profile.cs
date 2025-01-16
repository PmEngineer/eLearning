using AutoMapper;
using ELearning.Request;
using ELearning_Core.Model.Master;

namespace ELearning.Profiles
{
    public class HelpDesk_Profile:Profile
    {
        public HelpDesk_Profile()
        {
            //CreateMap<ELearning_Core.Model.Student.StudentInfo, ELearning.Request.StudentInfoRequest>().ReverseMap();
            CreateMap<HelpDesk, HelpDesk_Request>().ReverseMap();

        }
    }
}
