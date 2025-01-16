using ELearning.Migrations;
using ELearning.Request;
using ELearning_Core.Core.Model;
using ELearning_Core.Model;
using ELearning_Core.Model.City;
using ELearning_Core.Model.Faculty;
using ELearning_Core.Model.Master;
using ELearning_Core.Shared;

namespace ELearning.Interface
{
    public interface IMasterService
    {
        #region comnpany
        public Task<List<Company>> GetCompanies();
        public Task<Result<int>> InsertCompany(Company company);
        public Task<Result<int>> UpdateCompany(Company company);
        public Task<Result<int>> DeleteCompany(int Id);
        #endregion

        #region Country
        public Task<List<Country>> GetCountries();
        public Task<Result<int>> InsertCountry(Country country);
        public Task<Result<int>> UpdateCountry(Country country);
        public Task<Result<int>> DeleteCountry(int Id);
        #endregion

        #region State
        public Task<List<State>> GetStates();

        public Task<Result<int>> InsertState(State state);
        public Task<Result<int>> UpdateState(State state);
        public Task<Result<int>> DeleteState(int Id);
        #endregion
        
        #region City
        public Task<List<City>> GetCities();

        public Task<Result<int>> InsertCity(City city);
        public Task<Result<int>> UpdateCity(City city);
        public Task<Result<int>> DeleteCity(int Id);
        #endregion

        #region subject
        public Task<List<Subject>> GetSubjects();
        
        public Task<Result<int>> InsertSubjects(Subject subject);
        public Task<Result<int>> UpdateSubjects(Subject subject);
        public Task<Result<int>> DeleteSubjects(int Id);
        #endregion

        #region lesson
        public Task<List<Lessons>> GetLessons();
        public Task<Result<int>> InsertLessons(Lessons lessons);
        public Task<Result<int>> UpdateLessons(Lessons lessons);
        public Task<Result<int>> DeleteLesson(int Id);
        #endregion

        #region Menu
        public Task<List<MainMenu>> GetMenu();
        public Task<Result<int>> InsertMenu(MainMenu mainMenu);
        public Task<Result<int>> UpdateMenu(MainMenu mainMenu);
        public Task<Result<int>> DeleteMenu(int Id);
        #endregion
        
        #region Submenu
        public Task<List<SubMenu>> GetSubMenu();
        public Task<Result<int>> InsertSubMenu(SubMenu subMenu);
        public Task<Result<int>> UpdateSubMenu(SubMenu subMenu);
        public Task<Result<int>> DeleteSubMenu(int Id);
        #endregion

        #region course
        public Task<List<Course>> GetCourse();
        public Task<Result<int>> InsertCourse(Course course);
        public Task<Result<int>> UpdateCourse(Course course);
        public Task<Result<int>> DeleteCourse(int Id);
        #endregion

        #region notification
        public Task<List<AppNotification>> GetNotification();
        public Task<Result<int>> InsertNotification(AppNotification notification);
        public Task<Result<int>> UpdateNotification(AppNotification notification);
        public Task<Result<int>> DeleteNotification(int Id);
        #endregion

        #region Trades
        public Task<List<Trade>> GetTrades();
        public Task<Result<int>> InsertTrade(Trade trade); 
        public Task<Result<int>> UpdateTrade(Trade trade);
        public Task<Result<int>> DeleteTrade(int Id);
        #endregion

        #region category
        public Task<List<Category>> GetCategories();
        public Task<Result<int>> InsertCategory(Category category);
        public Task<Result<int>> UpdateCategory(Category category);
        public Task<Result<int>> DeleteCategory(int Id);
        #endregion

        #region subcategory
        public Task<List<SubCategory>> GetSubCategories();
        public Task<Result<int>> InsertSubCategory(SubCategory subcategory);
        public Task<Result<int>> UpdateSubCategory(SubCategory subcategory);
        public Task<Result<int>> DeleteSubCategory(int Id);
        #endregion

        #region post
        public Task<List<Post>> GetPosts();
        public Task<Result<int>> InsertPost(Post post);
        public Task<Result<int>> UpdatePost(Post post);
        public Task<Result<int>> DeletePost(int Id);
        #endregion

        #region Doubt
        public Task<List<Doubt>> GetDoubts();
        public Task<Result<int>> InsertDoubt(Doubt doubt);
        #endregion

        #region DoubtComment
        public Task <List<DoubtComment>> GetDoubtComments();
        public Task<Result<int>> InsertDoubtComment(DoubtComment doubtComment);
        #endregion

        #region pdfnotes
        public Task<List<PdfNote>> GetPdfNotes();
        public Task<Result<int>> InsertPdfNote(PdfNote pdfnote);
        public Task<Result<int>> UpdatePdfNote(PdfNote pdfnote);
        public Task<Result<int>> DeletePdfNote(int Id);

        #endregion

        #region previuosYearNote

        public Task<List<PreviousYearPaper>> GetPaperPdf();
        public Task<Result<int>> InsertPaper(PreviousYearPaper paper);
        public Task<Result<int>> UpdatePaper(PreviousYearPaper paper);
        public Task<Result<int>> DeletePaper(int Id);

        #endregion

        #region Licence

        public Task<List<Licence>> GetLicences();
        public Task<Result<int>> InsertLicence(Licence licence);
        public Task<Result<int>> UpdateLicence(Licence licence);
        public Task<Result<int>> DeleteLicence(int Id);

        #endregion

        #region Book
        public Task<List<Book>> GetBooks();
        public Task<Result<int>> InsertBook(Book book);
        public Task<Result<int>> UpdateBook(Book book);
        public Task<Result<int>> DeleteBook(int Id);
        #endregion

        #region Faculty
        public Task<List<Faculty>> GetFaculties();
        public Task <Result<int>> InsertFaculty(Faculty faculty);
        public Task<Result<int>> UpdateFaculty(Faculty faculty);
        public Task<Result<int>> DeleteFaculty(int Id);
        #endregion

        #region Batch
        public Task<List<Batch>> GetBatches();
        public Task<Result<int>> InsertBatch(BatchRequest batch);
        public Task<Result<int>> UpdateBatch(Batch batch);
        public Task<Result<int>> DeleteBatch(int Id);
        #endregion

        #region Assign Batch Subject
        public Task<List<BatchSubject>> GetBatchSubjects(); 
        public Task<Result<int>> InsertBatchSubjects(BatchSubject batchSubject);
        public Task<Result<int>> UpdateBatchSubjects(   BatchSubject batchSubject); 
        public Task<Result<int>> DeleteBatchSubject(int Id);
        #endregion
       
        #region HelpDesk
        public Task<Result<List<HelpDesk>>> GetAllProblems();
        public Task<Result<List<HelpDesk>>> GetProblemsByStdId(int Id);
        public Task<Result<int>> InsertProblems(HelpDesk helpDesk);
        public Task<Result<int>> Updateproblems(HelpDesk helpDesk);
        #endregion
    }
}
