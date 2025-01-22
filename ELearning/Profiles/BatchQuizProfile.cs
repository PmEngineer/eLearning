using AutoMapper;

namespace ELearning.Profiles
{
    public class BatchQuizProfile:Profile
    {
        public BatchQuizProfile()
        {
            CreateMap<ELearning_Core.Model.Quiz.BatchQuiz,ELearning.Response.BatchQuizResponse>().ReverseMap();
            CreateMap<ELearning_Core.Model.Quiz.QuizOption, ELearning.Response.QuizOptionResponse>().ReverseMap();
        }
    }
}
