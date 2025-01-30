using AutoMapper;

namespace ELearning.Profiles
{
    public class QuizAnswerProfile:Profile
    {
        public QuizAnswerProfile()
        {
            CreateMap<ELearning_Core.Model.Quiz.QuizAnswer,ELearning.Request.QuizAnswerRequest>().ReverseMap();
        }
    }
}
