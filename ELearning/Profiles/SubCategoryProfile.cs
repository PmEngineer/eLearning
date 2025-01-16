using AutoMapper;

namespace ELearning.Profiles
{
    public class SubCategoryProfile:Profile
    {
        public SubCategoryProfile() 
        { 
        
            CreateMap<ELearning_Core.Model.Master.SubCategory,ELearning.Response.SubcategoryResponse>().ReverseMap();
                
        }
    }
}
