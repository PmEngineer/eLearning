using ELearning_Core.Model;

namespace ELearning.Interface
{
    public interface ICompanyService
    {

        public Company CompanyLogin(string username, string password); 
    }
}
