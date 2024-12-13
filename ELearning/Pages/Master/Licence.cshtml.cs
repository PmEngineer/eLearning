using AspNetCoreHero.ToastNotification.Abstractions;
using ELearning.Interface;
using ELearning_Core.Model.Master;
using ELearning_Core.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ELearning.Pages.Master
{
    public class LicenceModel : PageModel
    {
        public readonly IMasterService _MasterService;
        private readonly INotyfService _notyf;
        private readonly UserManager<IdentityUser> _UserManager;

        public LicenceModel(IMasterService masterService, INotyfService notyf, UserManager<IdentityUser> userManager)
        {
            _MasterService = masterService;
            _notyf = notyf;
            _UserManager = userManager;
        }
        [Parameter]
        public int Id { get; set; }
        public string userId { get; set; }
        [BindProperty]
        public string value { get; set; } = "Save";
        [BindProperty]
        public Licence licence { get; set; } = new();
        public List<Licence> licences { get; set; } = new();
        public List<Company> getCompanies { get; set; } = new();
        public async Task OnGetAsync(int Id)
        {
            await GetCompanies();
            licences = await _MasterService.GetLicences();
            if (Id > 0)
            {
                var licencedata = licences.Where(x => x.Id == Id).FirstOrDefault();
                if (licencedata != null)
                {
                    licence.Id = licencedata.Id;
                    licence.LicenceKey = licencedata.LicenceKey;
                    licence.StartDate = licencedata.StartDate;
                    licence.EndDate = licencedata.EndDate;
                    licence.Duration = licencedata.Duration;
                    licence.CompanyId = licencedata.CompanyId;
                    licence.CreatedBy = licencedata.CreatedBy;
                    licence.CreatedDate = licencedata.CreatedDate;
                    licence.UpdatedDate = licencedata.UpdatedDate;
                    licence.UpdatedBy = licencedata.UpdatedBy;

                }
                value = "Update";
            }
        }
        public async Task GetCompanies()
        {
            var companyList = await _MasterService.GetCompanies();
            getCompanies = companyList.ToList();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var user = _UserManager.GetUserId(User);
            userId = user;
            if (licence.Id == 0)
            {
                licence.CreatedDate = DateTime.Now;
                licence.CreatedBy = _UserManager.GetUserId(User);
                var data = await _MasterService.InsertLicence(licence);
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
                licence.UpdatedDate = DateTime.Now;
                licence.UpdatedBy = _UserManager.GetUserId(User);
                var data = await _MasterService.UpdateLicence(licence);
                if (data.Succeeded)
                {
                    _notyf.Success(data.Messages[0]);
                }
                else
                {
                    _notyf.Success(data.Messages[0]);
                }
            }

            return Redirect("Licence");
        }
        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var data = await _MasterService.DeleteLicence(Id);
            if (data.Succeeded)
            {
                _notyf.Success(data.Messages[0]);
            }
            else
            {
                _notyf.Error(data.Messages[0]);
            }
            return Redirect("Licence");
        }

    }
}
