using AutoMapper;

namespace ELearning.Profiles
{
    public class QuizOptionProfile:Profile
    {
        public QuizOptionProfile()
        {
            CreateMap<ELearning_Core.Model.Quiz.QuizOption, ELearning.Response.BatchQuizResponse>().ReverseMap();
        }
    }
}
