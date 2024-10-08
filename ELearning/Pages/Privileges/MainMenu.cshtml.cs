using ELearning_Core.Model;
using ELearning.Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace ELearning.Pages.Privileges
{

    public class MainMenuModel : PageModel
    {
        public readonly IMasterService _MasterService;
        private readonly INotyfService _notyf;
        private UserManager<IdentityUser> _UserManager;
        public MainMenuModel(IMasterService masterService, INotyfService notyf, UserManager<IdentityUser> userManager)
        {
            _MasterService = masterService;
            _notyf = notyf;
            _UserManager = userManager;
        }
       
        public int submenuId { get; set; } = 11;
        public string userId { get; set; } 
        [BindProperty]
        public MainMenu mainMenu { get; set; } = new();
        public List<MainMenu> mainMenus { get; set; } = new();
        [Parameter] public string Id { get; set; }
        public string value { get; set; } = "Save";

        public async Task OnGetAsync(int Id)
        {
            var user = _UserManager.GetUserId(User);
            userId = user;
            await getData();
            if (Id > 0)
            {
                var mainMenudata = mainMenus.Where(s => s.Id == Id).FirstOrDefault();
                if (mainMenudata != null)
                {
                    mainMenu.Id = mainMenudata.Id;
                    mainMenu.MainMenuName = mainMenudata.MainMenuName;
                    mainMenu.MenuURL = mainMenudata.MenuURL;
                    mainMenu.MenuPriority = mainMenudata.MenuPriority;
                    mainMenu.IsMenuActive= mainMenudata.IsMenuActive;
                    mainMenu.CreatedDate = mainMenudata.CreatedDate;
                    mainMenu.CreatedBy = mainMenudata.CreatedBy;
                }
                value = "Update";
            }
            else
            {
                mainMenu.IsMenuActive = true;
            }
        }

        public async Task getData()
        {
            mainMenus = await _MasterService.GetMenu();
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            var user = _UserManager.GetUserId(User);
            userId = user;
            if (mainMenu.Id == 0)
            {
                mainMenu.CreatedDate = DateTime.Now;
                mainMenu.CreatedBy = _UserManager.GetUserId(User);
                var data = await _MasterService.InsertMenu(mainMenu);
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
                mainMenu.UpdatedDate = DateTime.Now;

                mainMenu.UpdatedBy = _UserManager.GetUserId(User);
                var data = await _MasterService.UpdateMenu(mainMenu);
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
            return Redirect("MainMenu");
        }
        public async Task<IActionResult> OnPostDeleteAsync(int Id)
        {
            var data = await _MasterService.DeleteMenu(Id);
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

            return Redirect("MainMenu");
        }
        public async Task Reset()
        {
            ModelState.Clear();

            await getData();
            mainMenu = new MainMenu();
        }
    }

}
