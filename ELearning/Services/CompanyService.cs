using ELearning.Interface;
using ELearning_Core.Model;

namespace ELearning.Services
{
    public class CompanyService : ICompanyService
    {
        public readonly IGenericRepository<Company> _company;

        public CompanyService(IGenericRepository<Company> company)
        {
            _company = company;
        }
        public bool CompanyLogin(string username, string password)
        {
             var data = _company.GetAllAsync(x=>x.Password == password && x.EmailId == username);
            if (data != null) { return true;
            }
            else { return false; }
        }
    }
}
