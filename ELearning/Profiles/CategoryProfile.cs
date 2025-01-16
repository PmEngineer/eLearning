using AutoMapper;

namespace ELearning.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile() 
        {
            CreateMap<ELearning_Core.Model.Master.Category,ELearning.Response.CategoryResponse>().ReverseMap();
        }
    }
}
