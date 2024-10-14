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
        public Company CompanyLogin(string username, string password)
        {
            Company c = new Company();
             var data = _company.GetAllAsync(x=>x.Password == password && x.EmailId == username);
            if (data != null) {
                c = data.Result.FirstOrDefault();
                return c;

            }
            else {
                return c;
            }
        }
    }
}
