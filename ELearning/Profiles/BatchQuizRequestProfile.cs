using AutoMapper;

namespace ELearning.Profiles
{
    public class BatchQuizRequestProfile:Profile
    {
        public BatchQuizRequestProfile()
        {
            CreateMap<ELearning_Core.Model.Quiz.BatchQuiz,ELearning.Request.BatchQuizRequest>().ReverseMap();
            CreateMap<ELearning_Core.Model.Quiz.QuizOption, ELearning.Request.QuizOptionRequest>().ReverseMap();
        }
    }
}
