using AspNetCoreHero.ToastNotification.Abstractions;
using ELearning.Interface;
using ELearning.SharedFileUpload;
using ELearning_Core.Model;
using ELearning_Core.Model.Master;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Utilities;

namespace ELearning.Pages.Master
{
    public class BookModel : PageModel
    {
        public readonly IMasterService _MasterService;
        private readonly INotyfService _notfy;
        private readonly UserManager<IdentityUser> _UserManager;
        public readonly IFileUploadSerVices _fileUploadSerVices;
        public BookModel(IMasterService masterService, INotyfService notyf, UserManager<IdentityUser> userManager, IFileUploadSerVices fileUploadSerVices)
        {
            _MasterService = masterService;
            _notfy = notyf;
            _UserManager = userManager;
            _fileUploadSerVices = fileUploadSerVices;
        }
        [Parameter]
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string userId { get; set; }
        public string value { get; set; } = "Save";
        public string bookFilePath { get; set; }
        [BindProperty]
        public Book book { get; set; } = new();
        public List<Course> GetCourses { get; set; } = new();
        public List<Book> books { get; set; } = new();
        public List<Subject> GetSubjects { get; set; }= new();
        public async Task OnGetAsync(int Id)
        {
            await getCourses();
            await getSubjects();
            books = await _MasterService.GetBooks();
            if(Id>0)
            {
                var bookData = books.Where(x => x.Id == Id).FirstOrDefault();
                if(bookData !=null)
                {
                    book.Id = bookData.Id;
                    book.BookName = bookData.BookName;
                    book.BookPdfFile = bookData.BookPdfFile;
                    book.CourseId = bookData.CourseId;
                    book.SubjectId = bookData.SubjectId;
                    book.CreatedBy = bookData.CreatedBy;
                    book.CreatedDate = bookData.CreatedDate;
                    book.UpdatedBy = bookData.UpdatedBy;
                    book.UpdatedDate = bookData.UpdatedDate;
                    book.IsPaid = bookData.IsPaid;
                    bookFilePath = bookData.BookPdfFile;
                }
                value = "Update";
            }    
        }
        public async Task getCourses()
        {
            var coursesList = await _MasterService.GetCourse();
            GetCourses = coursesList.ToList();
        }
        public async Task getSubjects()
        {
            var subjectsList = await _MasterService.GetSubjects();
            GetSubjects = subjectsList.Where(s => s.IsActive == true).ToList();
        }
        public async Task<IActionResult> OnPostAsync(IFormFile formFile, string targetFolder)
        {
            if(formFile !=null)
            {
                bookFilePath = await _fileUploadSerVices.UplodeFileAsync(formFile, targetFolder);
            }
            var user = _UserManager.GetUserId(User);
            userId = user;
            if(book.Id==0)
            {
                string filename = Path.GetFileName(bookFilePath);
                book.CreatedBy = user;
                book.CreatedDate = DateTime.Now;
                book.BookPdfFile = filename;
                var data = await _MasterService.InsertBook(book);
                if (data.Succeeded)
                {
                    _notfy.Success(data.Messages[0]);
                }
                else
                {
                    _notfy.Error(data.Messages[0]);
                }
            }
            else
            {
                string filename = Path.GetFileName(bookFilePath);
                if(filename!=null)
                {
                    book.BookPdfFile = filename;
                }
                book.UpdatedBy = user;
                book.UpdatedDate = DateTime.Now;
                var data = await _MasterService.UpdateBook(book);
                if (data.Succeeded)
                {
                    _notfy.Success(data.Messages[0]);
                }
                else
                {
                    _notfy.Error(data.Messages[0]);
                }
            }
            return Redirect("Book");
        }
        public async Task<IActionResult> OnPostDelete(int Id)
        {
            var data = await _MasterService.DeleteBook(Id);
            if (data.Succeeded)
            {
                _notfy.Success(data.Messages[0]);
            }
            else
            {
                _notfy.Error(data.Messages[0]);
            }
            return Redirect("Book");
        }
    }
}
