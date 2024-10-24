using AspNetCoreHero.ToastNotification.Abstractions;
using ELearning.Post_Img_Service;
using ELearning.Interface;
using ELearning_Core.Model.Master;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ELearning.Pages.Master
{
    public class PostModel : PageModel
    {
        public readonly IMasterService _MasterService;
        private readonly INotyfService _notyf;
        private UserManager<IdentityUser> _UserManager;
        public readonly IFileUploadSerVice _fileUplodeService;
        public PostModel(IMasterService masterService, INotyfService notyf, UserManager<IdentityUser> userManager, IFileUploadSerVice fileUplodeService)
        {
            _MasterService = masterService;
            _notyf = notyf;
            _UserManager = userManager;
            _fileUplodeService = fileUplodeService;
        }
        [Parameter]
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string userId { get; set; }
        public string value { get; set; } = "Save";
        public string IMagePath { get; set; }
        [BindProperty]
        public Post post { get; set; } = new();

        public List<Post> posts { get; set; } = new();
        public async Task OnGetAsync(int Id)
        {
            posts = await _MasterService.GetPosts();
            if (Id > 0)
            {
                var postdata = posts.Where(x => x.Id == Id).FirstOrDefault();

                if (postdata != null)
                {
                    post.Id = postdata.Id;
                    post.Image = postdata.Image;
                    post.IsExplore = postdata.IsExplore;
                    post.IsBuyNow = postdata.IsBuyNow;
                    post.IsActive = postdata.IsActive;
                    post.TotalComment = postdata.TotalComment;
                    post.TotalView = postdata.TotalView;
                    post.Description = postdata.Description;
                    post.CreatedDate = postdata.CreatedDate;
                    post.CreatedBy = postdata.CreatedBy;
                    post.UpdatedBy = postdata.UpdatedBy;
                    post.UpdatedDate = postdata.UpdatedDate;
                    IMagePath = postdata.Image;

                }
                value = "Update";
            }

        }

        public async Task<IActionResult> OnPostAsync(IFormFile formFile)
        {
            if (formFile != null)
            {
                FilePath = await _fileUplodeService.UplodeFileAsync(formFile);
            }

            var user = _UserManager.GetUserId(User);
            userId = user;

            if (post.Id == 0)
            {
                string fileName = Path.GetFileName(FilePath);
                post.CreatedBy = user;
                post.CreatedDate = DateTime.Now;
                post.Image = fileName;
                var data = await _MasterService.InsertPost(post);
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
                string fileName = Path.GetFileName(FilePath);
                if (fileName != null)
                {
                    post.Image = fileName;
                }

                post.UpdatedBy = user;
                post.UpdatedDate = DateTime.Now;
                var data = await _MasterService.UpdatePost(post);
                if (data.Succeeded)
                {
                    _notyf.Success(data.Messages[0]);
                }
                else
                {
                    _notyf.Error(data.Messages[0]);
                }
            }

            return Redirect("Post");
        }

        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var data = await _MasterService.DeletePost(Id);
            if (data.Succeeded)
            {
                _notyf.Success(data.Messages[0]);
            }
            else
            {
                _notyf.Error(data.Messages[0]);
            }
            return Redirect("Post");
        }

    }
}
