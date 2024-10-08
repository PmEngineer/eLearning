using ELearning_Core.Model;
using ELearning.Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace ELearning.Pages.Master
{
    public class CompanyModel : PageModel
    {
        public readonly IMasterService _masterService;
        private UserManager<IdentityUser> _userManager;
        private readonly INotyfService _notyf;

        public CompanyModel(IMasterService masterService, UserManager<IdentityUser> userManager, INotyfService notyf)
        {
            _masterService = masterService;
            _userManager = userManager;
            _notyf = notyf;
            
        }
        [BindProperty]

        public Company company { get; set; } = new();
        public List<Company> Companys { get; set; } = new ();

        [Parameter]
        public int Id { get; set; }

        public string value { get; set; } = "Save";
        public async Task OnGetAsync(int Id)
        {
            Companys = await _masterService.GetCompanies();
          
            if (Id > 0)
            {
                var companydata = Companys.Where(x => x.Id == Id).FirstOrDefault();
                if (companydata != null)
                {
                    company.Id = companydata.Id;
                    company.Name = companydata.Name;
                    company.Address = companydata.Address;
                    company.EmailId = companydata.EmailId;
                    company.ContactNo = companydata.ContactNo;
                    company.GSTNo = companydata.GSTNo;
                    company.CreatedBy = companydata.CreatedBy;
                    company.CreatedDate = companydata.CreatedDate;
                    company.UpdatedBy = companydata.UpdatedBy;
                    company.UpdatedDate = companydata.UpdatedDate;

                }
                value = "Update";
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = _userManager.GetUserId(User);
            if (company.Id ==0) 
            {
                company.CreatedDate = DateTime.Now;
                company.CreatedBy = _userManager.GetUserId(User);
                var data = await _masterService.InsertCompany(company);
                if (data.Succeeded)
                {
                    _notyf.Success(data.Messages[0]);
                }
                else
                {
                    _notyf.Error(data.Messages[0]);
                }
            }
            else
            {
                company.UpdatedDate = DateTime.Now;
                company.UpdatedBy = _userManager.GetUserId(User);
                var data = await _masterService.UpdateCompany(company);
                if (data.Succeeded)
                {
                    _notyf.Success(data.Messages[0]);
                }
                else
                {
                    _notyf.Error(data.Messages[0]);
                }
            }
            return Redirect("Company");
        }
        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var data = await _masterService.DeleteCompany(Id);

            if (data.Succeeded)
            {
                _notyf.Success(data.Messages[0]);
            }
            else
            {
                _notyf.Error(data.Messages[0]);
            }
            return Redirect("Company");
        }


    }
}
