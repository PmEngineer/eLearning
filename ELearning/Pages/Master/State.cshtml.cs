using ELearning_Core.Model;
using ELearning.Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ELearning_Core.Model.Master;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace ELearning.Pages.Master
{

    public class StateModel : PageModel
    {
        public readonly IMasterService _MasterService;
       
        private UserManager<IdentityUser> _UserManager;
        private readonly INotyfService _notyf;
        public StateModel(IMasterService masterService, UserManager<IdentityUser> UserManager, INotyfService notyf)
        {
            _MasterService = masterService;
            _UserManager = UserManager;
            _notyf = notyf;
        }
     
        public string userId { get; set; }
        [BindProperty]
        public State state { get; set; } = new();
        public List<State> states { get; set; } = new();
        public List<Country> countries { get; set; } = new();

        [Parameter] public int Id { get; set; }
        public string value { get; set; } = "Save";
        public async Task OnGetAsync(int Id)
        {
            var user = _UserManager.GetUserId(User);
            userId = user;
            await getData();
            await getCountries();
            if (Id > 0)
            {
                var statedata = states.Where(s => s.Id == Id).FirstOrDefault();
                if (statedata != null)
                {
                    state.Id = statedata.Id;
                    state.Name = statedata.Name;
                    state.CountryId = statedata.CountryId;
                    state.IsActive = statedata.IsActive;
                    state.CreatedDate = statedata.CreatedDate;
                    state.CreatedBy = statedata.CreatedBy;
                }
                value = "Update";
            }
            else
            {
                state.IsActive = true;
            }
        }

        public async Task getData()
        {
            states = await _MasterService.GetStates();
        }
        public async Task getCountries()
        {
           var  countriesList = await _MasterService.GetCountries();
            countries= countriesList.Where(s => s.IsActive==true).ToList();   
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var user = _UserManager.GetUserId(User);
            userId = user;
         
                if (state.Id == 0)
                {
                    state.CreatedDate = DateTime.Now;
                    state.CreatedBy = _UserManager.GetUserId(User);
                    var data = await _MasterService.InsertState(state);
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
                    state.UpdatedDate = DateTime.Now;
                    state.UpdatedBy = _UserManager.GetUserId(User);
                    var data = await _MasterService.UpdateState(state);
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
            
            return Redirect("State");
        }
        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var data = await _MasterService.DeleteState(Id);
            if (data.Succeeded)
            {
                _notyf.Success(data.Messages[0]);
            }
            else
            {
                _notyf.Error(data.Messages[0]);
            }
            await Reset();
            return Redirect("State");
        }
        public async Task Reset()
        {
            ModelState.Clear();

            await getData();
            await getCountries();
            state = null;
        }
    }
}
