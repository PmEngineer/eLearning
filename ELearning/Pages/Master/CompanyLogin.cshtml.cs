using AspNetCoreHero.ToastNotification.Abstractions;
using ELearning.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ELearning.Pages.Master
{
    public class CompanyLoginModel : PageModel
    {

        public readonly ICompanyService _companyService;
        private UserManager<IdentityUser> _UserManager;
        private readonly INotyfService _notfy;
        [BindProperty]
        public string username {  get; set; }
        [BindProperty]
        public string password { get; set; }

      
        public CompanyLoginModel(ICompanyService companyService, UserManager<IdentityUser> userManager, INotyfService notfy)
        {
            _companyService = companyService;
            _UserManager = userManager;
            _notfy = notfy;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var data =  _companyService.CompanyLogin(username, password);
            if (data)
            {
                _notfy.Success("Login");

            }
            else
            {
                _notfy.Success("Not login");
            }

            return Redirect("CompanyLogin");
        }
    }
}
