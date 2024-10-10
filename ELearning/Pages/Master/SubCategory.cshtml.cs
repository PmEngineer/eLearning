using AspNetCoreHero.ToastNotification.Abstractions;
using ELearning.Interface;
using ELearning_Core.Model.Master;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ELearning.Pages.Master
{
    public class SubCategoryModel : PageModel
    {
        public readonly IMasterService _MasterService;

        private UserManager<IdentityUser> _UserManager;
        private readonly INotyfService _notyf;
        public SubCategoryModel(IMasterService masterService, UserManager<IdentityUser> UserManager, INotyfService notyf)
        {
            _MasterService = masterService;
            _UserManager = UserManager;
            _notyf = notyf;
        }

        public string userId { get; set; }
        [BindProperty]
        public SubCategory subcategory { get; set; } = new();
        public List<SubCategory> subCategories { get; set; } = new();
        public List<Category> categories { get; set; } = new();

        [Parameter] public int Id { get; set; }
        public string value { get; set; } = "Save";
        public async Task OnGetAsync(int Id)
        {
            var user = _UserManager.GetUserId(User);
            userId = user;
            await getData();
            await getCategories();
            if (Id > 0)
            {
                var subcategorydata = subCategories.Where(s => s.Id == Id).FirstOrDefault();
                if (subcategorydata != null)
                {
                    subcategory.Id = subcategorydata.Id;
                    subcategory.Name = subcategorydata.Name;
                    subcategory.CategoryId = subcategorydata.CategoryId;
                    subcategory.IsActive = subcategorydata.IsActive;
                    subcategory.CreatedDate = subcategorydata.CreatedDate;
                    subcategory.CreatedBy = subcategorydata.CreatedBy;
                }
                value = "Update";
            }
            else
            {
                subcategory.IsActive = true;
            }
        }

        public async Task getData()
        {
            subCategories = await _MasterService.GetSubCategories();
        }
        public async Task getCategories()
        {
            var categoriesList = await _MasterService.GetCategories();
           categories = categoriesList.Where(s => s.IsActive == true).ToList();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var user = _UserManager.GetUserId(User);
            userId = user;

            if (subcategory.Id == 0)
            {
                subcategory.CreatedDate = DateTime.Now;
                subcategory.CreatedBy = _UserManager.GetUserId(User);
                var data = await _MasterService.InsertSubCategory(subcategory);
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
                subcategory.UpdatedDate = DateTime.Now;
                subcategory.UpdatedBy = _UserManager.GetUserId(User);
                var data = await _MasterService.UpdateSubCategory(subcategory);
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

            return Redirect("SubCategory");
        }
        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var data = await _MasterService.DeleteSubCategory(Id);
            if (data.Succeeded)
            {
                _notyf.Success(data.Messages[0]);
            }
            else
            {
                _notyf.Error(data.Messages[0]);
            }
            await Reset();
            return Redirect("SubCategory");
        }
        public async Task Reset()
        {
            ModelState.Clear();

            await getData();
            await getCategories();
            subcategory = null;
        }
    }
}
