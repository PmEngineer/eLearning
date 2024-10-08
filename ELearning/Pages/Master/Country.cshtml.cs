using AspNetCoreHero.ToastNotification.Abstractions;
using ELearning.Interface;
using ELearning_Core.Model.Master;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ELearning.Pages.Master
{
    public class CountryModel : PageModel
    {
        public readonly IMasterService _MasterService;
   
        private UserManager<IdentityUser> _UserManager;
        private readonly INotyfService _notyf;
        public CountryModel(IMasterService masterService, UserManager<IdentityUser> UserManager, INotyfService notyf)
        {
            _MasterService = masterService;
  
            _UserManager = UserManager;
            _notyf= notyf;
        }

        public string userId { get; set; }
        [BindProperty]
        public Country country { get; set; } = new();
        public List<Country> countries { get; set; } = new();
        [Parameter] public int Id { get; set; }
        public string value { get; set; } = "Save";
        public async Task OnGetAsync(int Id)
        {
            var user = _UserManager.GetUserId(User);
            userId = user;
            await getData();
            if (Id > 0)
            {
                var countrydata = countries.Where(c => c.Id == Id).FirstOrDefault();
                if (countrydata != null)
                {
                    country.Name = countrydata.Name;
                    country.Id = countrydata.Id;
                    country.IsActive = countrydata.IsActive;
                    country.CreatedDate = countrydata.CreatedDate;
                    country.CreatedBy = countrydata.CreatedBy;
                }
                value = "Update";
            }
            else
            {
                country.IsActive = true;
            }
        }

        public async Task getData()
        {
            countries = await _MasterService.GetCountries();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var user = _UserManager.GetUserId(User);
            userId = user;
            if (country.Id == 0)
                {
                    country.CreatedDate = DateTime.Now;
                    country.CreatedBy = _UserManager.GetUserId(User);
                    var data = await _MasterService.InsertCountry(country);
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
                    country.UpdatedDate = DateTime.Now;
                    country.UpdatedBy = _UserManager.GetUserId(User);
                    var data = await _MasterService.UpdateCountry(country);
                if (data.Succeeded)
                {
                    _notyf.Success(data.Messages[0]);
                }
                else
                {
                    _notyf.Error(data.Messages[0]);
                }
            }
                await Reset();
            
            return Redirect("Country");
        }
        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var data = await _MasterService.DeleteCountry(Id);
            if (data.Succeeded)
            {
                _notyf.Success(data.Messages[0]);
            }
            else
            {
                _notyf.Error(data.Messages[0]);
            }
            await Reset();
            return RedirectToPage("Country");
        }

        public async Task Reset()
        {
            ModelState.Clear();

            await getData();
            country = new Country();
        }

    }
}
