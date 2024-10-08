using ELearning_Core.Model;
using ELearning.Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ELearning_Core.Model.Master;
using AspNetCoreHero.ToastNotification.Abstractions;
using ELearning_Core.Core.Model;

namespace ELearning.Pages.Privileges
{

    public class SubMenuModel : PageModel
    {
        public readonly IMasterService _MasterService;
        private readonly INotyfService _notyf;
        private UserManager<IdentityUser> _UserManager;

        public SubMenuModel(IMasterService masterService, INotyfService notyf, UserManager<IdentityUser> userManager)
        {
            _MasterService = masterService;
            _notyf = notyf;
            _UserManager = userManager;
        }
      
        public int submenuId { get; set; } =12 ;
        public string userId { get; set; } 
        [BindProperty]
        public SubMenu subMenu { get; set; } = new();
        public List<SubMenu> subMenus { get; set; } = new();
        public List<MainMenu> mainMenus { get; set; } = new();
        [Parameter] public string Id { get; set; }
        public string value { get; set; } = "Save";

        public async Task OnGetAsync(int Id)
        {
            var user = _UserManager.GetUserId(User);
            userId = user;
            await getData();
            await getMainMenu();
            if (Id > 0)
            {
                var subMenudata = subMenus.Where(s => s.Id == Id).FirstOrDefault();
                if (subMenudata != null)
                {
                    subMenu.Id = subMenudata.Id;
                    subMenu.SubMenuName = subMenudata.SubMenuName;
                    subMenu.MainMenuId = subMenudata.MainMenuId;
                    subMenu.MenuUrl = subMenudata.MenuUrl;
                    subMenu.MenuPriority = subMenudata.MenuPriority;
                    subMenu.IsSubMenuActive = subMenudata.IsSubMenuActive;
                    subMenu.CreatedDate = subMenudata.CreatedDate;
                    subMenu.CreatedBy = subMenudata.CreatedBy;
                }
                value = "Update";
            }
            else
            {
                subMenu.IsSubMenuActive = true;
            }
        }

        public async Task getData()
        {
            subMenus = await _MasterService.GetSubMenu();
        }
        public async Task getMainMenu()
        {
            var mainMenusList = await _MasterService.GetMenu();
            mainMenus = mainMenusList.Where(s => s.IsMenuActive == true).ToList();

        }
        public async Task<IActionResult> OnPostAsync()
        {
            var user = _UserManager.GetUserId(User);
            userId = user;
            if (subMenu.Id == 0)
            {
                subMenu.CreatedDate = DateTime.Now;
                subMenu.CreatedBy = _UserManager.GetUserId(User);
                var data = await _MasterService.InsertSubMenu(subMenu);
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
                subMenu.UpdatedDate = DateTime.Now;

                subMenu.UpdatedBy = _UserManager.GetUserId(User);
                var data = await _MasterService.UpdateSubMenu(subMenu);
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
            return Redirect("subMenu");
        }
        public async Task<IActionResult> OnPostDeleteAsync(int Id)
        {
            var data = await _MasterService.DeleteSubMenu(Id);
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

            return Redirect("subMenu");
        }
        public async Task Reset()
        {
            ModelState.Clear();

            await getData();
            await getMainMenu();
            subMenu = new SubMenu();
        }
    }
}
