using ELearning_Core.Core.Model;
using ELearning_Core.Model;
using ELearning_Core.Model.City;
using ELearning_Core.Model.Master;
using ELearning_Core.Shared;

namespace ELearning.Interface
{
    public interface IMasterService
    {
        public Task<List<Company>> GetCompanies();
        public Task<Result<int>> InsertCompany(Company company);
        public Task<Result<int>> UpdateCompany(Company company);
        public Task<Result<int>> DeleteCompany(int Id);
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

        public Task<List<Subject>> GetSubjects();
        
        public Task<Result<int>> InsertSubjects(Subject subject);
        public Task<Result<int>> UpdateSubjects(Subject subject);
        public Task<Result<int>> DeleteSubjects(int Id);

        public Task<List<Lessons>> GetLessons();
        public Task<Result<int>> InsertLessons(Lessons lessons);
        public Task<Result<int>> UpdateLessons(Lessons lessons);
        public Task<Result<int>> DeleteLesson(int Id);

        public Task<List<MainMenu>> GetMenu();
        public Task<Result<int>> InsertMenu(MainMenu mainMenu);
        public Task<Result<int>> UpdateMenu(MainMenu mainMenu);
        public Task<Result<int>> DeleteMenu(int Id);

        public Task<List<SubMenu>> GetSubMenu();
        public Task<Result<int>> InsertSubMenu(SubMenu subMenu);
        public Task<Result<int>> UpdateSubMenu(SubMenu subMenu);
        public Task<Result<int>> DeleteSubMenu(int Id); 

        public Task<List<Course>> GetCourse();
        public Task<Result<int>> InsertCourse(Course course);
        public Task<Result<int>> UpdateCourse(Course course);
        public Task<Result<int>> DeleteCourse(int Id);


        public Task<List<AppNotification>> GetNotification();
        public Task<Result<int>> InsertNotification(AppNotification notification);
        public Task<Result<int>> UpdateNotification(AppNotification notification);
        public Task<Result<int>> DeleteNotification(int Id);

        public Task<List<Trade>> GetTrades();
        public Task<Result<int>> InsertTrade(Trade trade); 
        public Task<Result<int>> UpdateTrade(Trade trade);
        public Task<Result<int>> DeleteTrade(int Id);

    }
}
