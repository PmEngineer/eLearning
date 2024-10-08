using ELearning_Core.Model;
using ELearning.Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ELearning_Core.Model.Master;
using ELearning_Core.Model.City;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace ELearning.Pages.Master
{

    public class CityModel : PageModel
    {
        public readonly IMasterService _MasterService;
        private readonly INotyfService _notyf;
        private UserManager<IdentityUser> _UserManager;
        public CityModel(IMasterService masterService, INotyfService notyf,UserManager<IdentityUser> UserManager)
        {
            _MasterService = masterService;
            _notyf= notyf;
            _UserManager = UserManager;
        }
      
  
        public string userId { get; set; }
        [BindProperty]
        public City city { get; set; } = new();
        public List<City> cities { get; set; } = new();
        public List<State> states { get; set; } = new();
        [Parameter] public string Id { get; set; }
        public string value { get; set; } = "Save";

        public async Task OnGetAsync(int Id)
        {
            var user = _UserManager.GetUserId(User);
            userId = user;
            await getData();
            await getStates();
            if (Id > 0)
            {
                var citydata = cities.Where(s => s.Id == Id).FirstOrDefault();
                if (citydata != null)
                {
                    city.Id = citydata.Id;
                    city.Name = citydata.Name;
                    city.StateId = citydata.StateId;
                    city.IsActive = citydata.IsActive;
                    city.CreatedDate = citydata.CreatedDate;
                    city.CreatedBy = citydata.CreatedBy;
                }
                value = "Update";
            }
            else
            {
                city.IsActive = true;
            }
        }

        public async Task getData()
        {
            cities = await _MasterService.GetCities();
        }
        public async Task getStates()
        {
            var statesList = await _MasterService.GetStates();
            states = statesList.Where(s=>s.IsActive==true).ToList();
            
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var user = _UserManager.GetUserId(User);
            userId = user;
           if (city.Id == 0)
                {
                    city.CreatedDate = DateTime.Now;
                    city.CreatedBy = _UserManager.GetUserId(User);
                    var data = await _MasterService.InsertCity(city);
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
                    city.UpdatedDate = DateTime.Now;

                    city.UpdatedBy = _UserManager.GetUserId(User);
                    var data = await _MasterService.UpdateCity(city);
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
            
            return Redirect("City");
        }
        public async Task<IActionResult> OnPostDeleteAsync(int Id)
        {
            var data = await _MasterService.DeleteCity(Id);
            if (data.Succeeded)
            {
                _notyf.Success(data.Messages[0]);
            }
            else
            {
                _notyf.Error(data.Messages[0]);
            }
            await Reset();
            await OnGetAsync(0);

            return Redirect("City");
        }
        public async Task Reset()
        {
            ModelState.Clear();

            await getData();
            await getStates();  
            city = new City();
        }
    }
}
