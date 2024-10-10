using AspNetCoreHero.ToastNotification.Abstractions;
using ELearning.Interface;
using ELearning_Core.Model.Master;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ELearning.Pages.Master
{
    public class CategoryModel : PageModel
    {
        public readonly IMasterService _MasterService;
        private UserManager<IdentityUser> _UserManager;
        private readonly INotyfService _notyf;

        public CategoryModel(IMasterService masterService, UserManager<IdentityUser> userManager, INotyfService notyf)
        {
            _MasterService = masterService;
            _UserManager = userManager;
            _notyf = notyf;
        }
        public string userId { get; set; }
        [BindProperty]
        public Category category { get; set; } = new();
        public List<Category> categories { get; set; } = new();
        public int Id { get; set; }
        [Parameter]

        public string value { get; set; } = "Save";
        public async Task OnGetAsync(int Id)
        {
            var user = _UserManager.GetUserId(User);
            userId = user;
            await getData();
            if (Id > 0)
            {
                var categorydata = categories.Where(c => c.Id == Id).FirstOrDefault();
                if (categorydata != null)
                {
                    category.Name = categorydata.Name;
                    category.Id = categorydata.Id;
                    category.IsActive = categorydata.IsActive;
                    category.CreatedDate = categorydata.CreatedDate;
                    category.CreatedBy = categorydata.CreatedBy;
                    category.UpdatedBy = categorydata.UpdatedBy;
                    category.UpdatedDate = categorydata.UpdatedDate;
                }
                value = "Update";
            }
            else
            {
                category.IsActive = true;
            }
        }

        public async Task getData()
        {
            categories = await _MasterService.GetCategories();
        }
        public async Task<IActionResult> OnPostAsync()
        {

            var user = _UserManager.GetUserId(User);
            userId = user;
            if (category.Id == 0)
            {
                category.CreatedDate = DateTime.Now;
                category.CreatedBy = _UserManager.GetUserId(User);
                var data = await _MasterService.InsertCategory(category);
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
                category.UpdatedDate = DateTime.Now;
                category.UpdatedBy = _UserManager.GetUserId(User);
                var data = await _MasterService.UpdateCategory(category);
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
            return Redirect("Category");
        }

        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var data = await _MasterService.DeleteCategory(Id);
            if (data.Succeeded)
            {
                _notyf.Success(data.Messages[0]);
            }
            else
            {
                _notyf.Error(data.Messages[0]);
            }
            await Reset();
            return RedirectToPage("Category");
        }

        public async Task Reset()
        {
            ModelState.Clear();
            await getData();
            category = new Category();
        }
    }
}
