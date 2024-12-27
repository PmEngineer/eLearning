using AspNetCoreHero.ToastNotification.Abstractions;
using ELearning.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ELearning_Core.Model;
using System.Threading.Tasks;

namespace ELearning.Pages.Master
{
    public class CompanyLoginModel : PageModel
    {
        private readonly ICompanyService _companyService;
        private readonly UserManager<IdentityUser> _UserManager;
        private readonly INotyfService _notfy;

        [BindProperty]
        public string username { get; set; }

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
            var company = await _companyService.CompanyLogin(username, password);
            if (company != null)
            {
                _notfy.Success("Login successful.");
                TempData["UserName"] = username;
                return Redirect("/CompanyDashboard");
            }
            else
            {
               
                _notfy.Error("Invalid username or password, or your company license might be invalid.");
                return Page(); 
            }
        }
    }
}