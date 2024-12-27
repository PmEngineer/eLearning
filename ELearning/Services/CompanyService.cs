using ELearning.Interface;
using ELearning_Core.Model;
using ELearning_Core.Model.Master;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ELearning.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IGenericRepository<Company> _companyRepository;
        private readonly IGenericRepository<Licence> _licenceRepository;

        public CompanyService(IGenericRepository<Company> companyRepository, IGenericRepository<Licence> licenceRepository)
        {
            _companyRepository = companyRepository;
            _licenceRepository = licenceRepository;
        }

        public async Task<Company> CompanyLogin(string username, string password)
        {
           
            var companies = await _companyRepository.GetAllAsync(x => x.EmailId == username );

          
            if (companies == null || !companies.Any())
            {
                return null;
            }
            var loggedCompany = companies.FirstOrDefault();

    
            if (loggedCompany.Password != password) 
            {
                return null; 
            }

        
            var licences = await _licenceRepository.GetAllAsync(l => l.CompanyId == loggedCompany.Id);
            if (licences == null || !licences.Any())
            {
                return null; 
            }

            var companyLicence = licences.FirstOrDefault();
          
            if (companyLicence.StartDate > DateTime.Now || companyLicence.EndDate < DateTime.Now)
            {
                return null;
            }

            
            return loggedCompany;
        }
    }
}