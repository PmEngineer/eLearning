using AutoMapper;

namespace ELearning.Profiles
{
    public class BookPdfProfile:Profile
    {
        public BookPdfProfile() 
        { 
            CreateMap<ELearning_Core.Model.Master.Book, ELearning.Request.BookPdfRequest>().ReverseMap();
        }
    }
}
