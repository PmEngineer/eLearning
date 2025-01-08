using AspNetCoreHero.ToastNotification.Abstractions;
using ELearning.Interface;
using ELearning.SharedFileUpload;
using ELearning_Core.Model;
using ELearning_Core.Model.Faculty;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ELearning.Pages.Master
{
    public class FacultyModel : PageModel
    {
        public readonly IMasterService _MasterService;
        private readonly INotyfService _notyf;
        private readonly UserManager<IdentityUser> _UserManger;
        public readonly IFileUploadSerVices _fileUploadSerVices;

        public FacultyModel(IMasterService masterService, INotyfService notfy, UserManager<IdentityUser> userManager,IFileUploadSerVices fileUploadSerVices)
        {
            _MasterService = masterService;
            _notyf = notfy;
            _UserManger = userManager;
            _fileUploadSerVices = fileUploadSerVices;
        }
        [Parameter]
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string userId { get; set; }
        public string value { get; set; } = "Save";
        public string ImagePath {  get; set; }
        [BindProperty]
        public Faculty Faculty { get; set; } = new();
        public List<Faculty> Faculties { get; set; } = new();
        public List<Company> getCompanies { get; set; } = new();

        public async Task OnGetAsync(int Id)
        {
            await GetCompanies();
             Faculties = await _MasterService.GetFaculties();
            if (Id > 0)
            {
                var facultyDate = Faculties.Where(x => x.Id == Id).FirstOrDefault();
                if (facultyDate != null)
                {
                    Faculty.Id = facultyDate.Id;
                    Faculty.Name= facultyDate.Name;
                    Faculty.Email= facultyDate.Email;
                    Faculty.Contact= facultyDate.Contact;
                    Faculty.Address= facultyDate.Address;
                    Faculty.Qualification= facultyDate.Qualification;
                    Faculty.CompanyId= facultyDate.CompanyId;
                    Faculty.CreatedBy= facultyDate.CreatedBy;
                    Faculty.CreatedDate= facultyDate.CreatedDate;
                    Faculty.UpdatedBy= facultyDate.UpdatedBy;
                    Faculty.UpdatedDate= facultyDate.UpdatedDate;
                    Faculty.Image= facultyDate.Image;
                    ImagePath = facultyDate.Image;
                }
                value = "Update";
            }
        }
        public async Task GetCompanies()
        {
           var companyList = await _MasterService.GetCompanies();
            getCompanies = companyList.ToList();
        }
        public async Task<IActionResult> OnPostAsync(IFormFile formFile, string targetFolder)
        {
            if(formFile !=null)
            {
                FilePath = await _fileUploadSerVices.UplodeFileAsync(formFile, targetFolder);
            }
            var user = _UserManger.GetUserId(User);
            userId = user;
            if (Faculty.Id == 0)
            {
                string filename = Path.GetFileName(FilePath);
                Faculty.CreatedBy = _UserManger.GetUserId(User);
                Faculty.CreatedDate = DateTime.Now;
                Faculty.Image = filename;
                var data = await _MasterService.InsertFaculty(Faculty);
                if(data.Succeeded)
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
                string filename=Path.GetFileName(FilePath);
                if(filename !=null)
                {
                    Faculty.Image = filename;
                }
                Faculty.UpdatedDate = DateTime.Now;
                Faculty.UpdatedBy = _UserManger.GetUserId(User);
                var data = await _MasterService.UpdateFaculty(Faculty);
                if (data.Succeeded)
                {
                    _notyf.Success(data.Messages[0]);
                }
                else
                {
                    _notyf.Error(data.Messages[0]);
                }
            }
            return Redirect("Faculty");
        }
        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var data = await _MasterService.DeleteFaculty(Id);
            if (data.Succeeded)
            {
                _notyf.Success(data.Messages[0]);
            }
            else
            {
                _notyf.Error(data.Messages[0]);
            }
            return Redirect("Faculty");
        }
    }
}
