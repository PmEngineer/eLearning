
using ELearning_Core.Shared;
using ELearning.Interface;
using ELearning_Core.Model;
using ELearning_Core.Model.City;
using ELearning_Core.Model.Master;
using ELearning_Core.Core.Model;
using System.Collections.Generic;

namespace ELearning.Services
{
    public class MasterService : IMasterService
    {
       public readonly IGenericRepository<Company> _companyRepository;
        public readonly IGenericRepository<Country> _countryRepository;
        public readonly IGenericRepository<State> _stateRepository;
        public readonly IGenericRepository<City> _cityRepository;
        public readonly IGenericRepository<Subject> _subjectRepository;
        public readonly IGenericRepository<Lessons> _lessonRepository;
        public readonly IGenericRepository<MainMenu> _menuRepository;
        public readonly IGenericRepository<SubMenu> _subMenuRepository;
        public readonly IGenericRepository<Course> _courseRepository;
        public readonly IGenericRepository<AppNotification> _notificationRepository;
        public readonly IGenericRepository<Trade> _tradeRepository;
        public readonly IGenericRepository<Category> _categoryRepository;
        public readonly IGenericRepository<SubCategory> _subcategoryRepository;
        public readonly IGenericRepository<Post> _postRepository;
    
        public MasterService(IGenericRepository<Company> companyRepository, IGenericRepository<Country> countryRepository , IGenericRepository<State> stateRepository, IGenericRepository<City> cityRepository, IGenericRepository<Subject> subjectRepository, IGenericRepository<Lessons> lessonRepository, IGenericRepository<MainMenu> menuRepository, IGenericRepository<SubMenu> subMenuRepository, IGenericRepository<Course> courseRepository, IGenericRepository<AppNotification> notificationRepository, IGenericRepository<Trade> tradeRepository , IGenericRepository<Category> categoryRepository, IGenericRepository<SubCategory> subcategoryRepository, IGenericRepository<Post> postRepository  )
        {
            _companyRepository = companyRepository;
            _countryRepository = countryRepository;
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
            _subjectRepository = subjectRepository;
            _lessonRepository = lessonRepository;
            _menuRepository = menuRepository;
            _subMenuRepository = subMenuRepository;
            _courseRepository = courseRepository;
            _notificationRepository = notificationRepository;
            _tradeRepository = tradeRepository;
            _categoryRepository = categoryRepository;
            _subcategoryRepository = subcategoryRepository;
            _postRepository = postRepository;

        }

        public async Task<List<Company>> GetCompanies()
        {
            try
            {
                var data = await _companyRepository.GetAllAsync();
                return data.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
     
        }

        public async Task<Result<int>> InsertCompany(Company company)
        {
            try
            {
                await _companyRepository.AddAsync(company);
                return await Result<int>.SuccessAsync(company.Id, "Company added");
            }
            catch (Exception ex) 
            { 
                throw;
            }
        }

        public async  Task<Result<int>> UpdateCompany(Company company)
        {
            try
            {
                await _companyRepository.UpdateAsync(company);
                return await Result<int>.SuccessAsync(company.Id, "Company Updated");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<Result<int>> DeleteCompany(int Id)
        {
            var data = await _companyRepository.GetByIdAsync(Id);
            if(data != null)
            {
                await _companyRepository.DeleteAsync(data);
                return await Result<int>.SuccessAsync("Compnay Deleted ");
            }
            else
            {
                return await Result<int>.FailAsync("Data Not Found");
            }
        }

        public async Task<Result<int>> DeleteCountry(int Id)
        {
            var data = await _countryRepository.GetByIdAsync(Id);
            if (data == null)
            {
                return await Result<int>.FailAsync("Country not found");
            }
            else
            {
                await _countryRepository.DeleteAsync(data);
                return await Result<int>.SuccessAsync("Country Deleted");
            }
        }

        public async Task<List<Country>> GetCountries()
        {


            var data = await _countryRepository.GetAllAsync();
            return data.ToList();


        }



        public async Task<Result<int>> InsertCountry(Country country)
        {
            await _countryRepository.AddAsync(country);
            return await Result<int>.SuccessAsync(country.Id, "Country Saved");
        }

        public async Task<Result<int>> UpdateCountry(Country country)
        {
            await _countryRepository.UpdateAsync(country);
            return await Result<int>.SuccessAsync(country.Id, "Country Update");
        }

        public async Task<List<State>> GetStates()
        {
            try
            {

                var data = await _stateRepository.GetAllAsync();
                return data.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Result<int>> InsertState(State state)
        {
            await _stateRepository.AddAsync(state);
            return await Result<int>.SuccessAsync(state.Id, "State Saved");
        }

        public async Task<Result<int>> UpdateState(State state)
        {
            await _stateRepository.UpdateAsync(state);
            return await Result<int>.SuccessAsync(state.Id, "State Update");
        }

        public async Task<Result<int>> DeleteState(int Id)
        {
            var data = await _stateRepository.GetByIdAsync(Id);
            if (data == null)
            {
                return await Result<int>.FailAsync("State not found");
            }
            else
            {
                await _stateRepository.DeleteAsync(data);
                return await Result<int>.SuccessAsync("State Deleted");
            }
        }
        public async Task<List<City>> GetCities()
        {
            try
            {

                var data = await _cityRepository.GetAllAsync();
                return data.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Result<int>> InsertCity(City city)
        {
            await _cityRepository.AddAsync(city);
            return await Result<int>.SuccessAsync(city.Id, "City Saved");
        }

        public async Task<Result<int>> UpdateCity(City city)
        {
            await _cityRepository.UpdateAsync(city);
            return await Result<int>.SuccessAsync(city.Id, "City Update");
        }

        public async Task<Result<int>> DeleteCity(int Id)
        {
            var data = await _cityRepository.GetByIdAsync(Id);
            if (data == null)
            {
                return await Result<int>.FailAsync("City not found");
            }
            else
            {
                await _cityRepository.DeleteAsync(data);
                return await Result<int>.SuccessAsync("City Deleted");
            }

        }

        public async Task<List<Subject>> GetSubjects()
        {
            try
            {
                var data = await _subjectRepository.GetAllAsync();
                return data.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<int>> InsertSubjects(Subject subject)
        {
            try
            {
                await _subjectRepository.AddAsync(subject);
                return await Result<int>.SuccessAsync(subject.Id, "Subject Added ");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<int>> UpdateSubjects(Subject subject)
        {
            try
            {
                await _subjectRepository.UpdateAsync(subject);
                return await Result<int>.SuccessAsync(subject.Id, "Subject Updated");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<int>> DeleteSubjects(int Id)
        {
            try
            {
                var data =await _subjectRepository.GetByIdAsync(Id);
                if(data == null)
                {
                    return await Result<int>.FailAsync("Data Not Found");
                }
                else
                {
                    await _subjectRepository.DeleteAsync(data);
                    return await Result<int>.SuccessAsync("Data Deleted ");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Lessons>> GetLessons()
        {
            try
            {
                var data = await _lessonRepository.GetAllAsync();
                return data.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Result<int>> InsertLessons(Lessons lessons)
        {
            try
            {
                await _lessonRepository.AddAsync(lessons);
                return await Result<int>.SuccessAsync(lessons.Id, "Lesson Added");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<Result<int>> UpdateLessons(Lessons lessons)
        {
           try
            {
                await _lessonRepository.UpdateAsync(lessons);
                return await Result<int>.SuccessAsync(lessons.Id, "Lesson Updated");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<int>> DeleteLesson(int Id)
        {
             try
            {
                var data = await _lessonRepository.GetByIdAsync(Id);
                if (data == null)
                {
                    return await Result<int>.FailAsync("Data Not Found");

                }
                else
                {
                    await _lessonRepository.DeleteAsync(data);
                    return await Result<int>.SuccessAsync("Data Deleted");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }


        }

        public async Task<List<MainMenu>> GetMenu()
        {
           try
            {
                var data = await _menuRepository.GetAllAsync();
                return data.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<int>> InsertMenu(MainMenu mainMenu)
        {
            try
            {
                await  _menuRepository.AddAsync(mainMenu);
                return await Result<int>.SuccessAsync(mainMenu.Id, "Menu Added");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<int>> UpdateMenu(MainMenu mainMenu)
        {
            try
            {
                await _menuRepository.UpdateAsync(mainMenu);
                return await Result<int>.SuccessAsync(mainMenu.Id, "Menu Updated");

            }
                
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<int>> DeleteMenu(int Id)
        {
            try
            {
                var data = await _menuRepository.GetByIdAsync(Id);
                if(data == null)
                {
                    return await Result<int>.FailAsync("Data Not Found");
                }
                else
                {
                    await _menuRepository.DeleteAsync(data);
                    return await Result<int>.SuccessAsync("Data Deleted");
                }
            }

        catch(Exception ex) 
            {

                throw ex;
            }

        }

        public async Task<List<SubMenu>> GetSubMenu()
        {
            try
            {
                var data = await _subMenuRepository.GetAllAsync();
                return data.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<int>> InsertSubMenu(SubMenu subMenu)
        {
           try
            {
                await _subMenuRepository.AddAsync(subMenu);
                return await Result<int>.SuccessAsync(subMenu.Id, "SubMenu Added");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<int>> UpdateSubMenu(SubMenu subMenu)
        {
            try
            {
                await _subMenuRepository.UpdateAsync(subMenu);
                return await Result<int>.SuccessAsync(subMenu.Id, "SubMenu Updated");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<int>> DeleteSubMenu(int Id)
        {
            try
            {
                var data = await _subMenuRepository.GetByIdAsync(Id);
                if(data == null)
                {
                    return await Result<int>.FailAsync("Data Not Found");
                }
                else
                {
                    await _subMenuRepository.DeleteAsync(data);
                    return await Result<int>.SuccessAsync("Data Deleted");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Course>> GetCourse()
        {
            try
            {
                var data = await _courseRepository.GetAllAsync();   
                return data.ToList();
            }
            catch(Exception ex)
            {
                throw ex;

            }
        }

        public async Task<Result<int>> InsertCourse(Course course)
        {
            try
            {
                await _courseRepository.AddAsync(course);
                return await Result<int>.SuccessAsync(course.Id, "Course Added");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<int>> UpdateCourse(Course course)
        {
            try
            {
                await _courseRepository.UpdateAsync(course);
                return await Result<int>.SuccessAsync(course.Id,"Course Updated");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<int>> DeleteCourse(int Id)
        {
            try
            {
                var data = await _courseRepository.GetByIdAsync(Id);
                if(data == null)
                {
                    return await Result<int>.FailAsync("Data Not Found");
                }
                else
                {
                    await _courseRepository.DeleteAsync(data);
                    return await Result<int>.SuccessAsync("Data Deleted");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<AppNotification>> GetNotification()
        {
            try
            {
                var data = await _notificationRepository.GetAllAsync();
                return data.ToList();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<Result<int>> InsertNotification(AppNotification notification)
        {
            try
            {
                await _notificationRepository.AddAsync(notification);
                return await Result<int>.SuccessAsync(notification.Id, "notification Added");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<int>> UpdateNotification(AppNotification notification)
        {
            try
            {
                await _notificationRepository.UpdateAsync(notification);
                return await Result<int>.SuccessAsync(notification.Id, " Updated");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<int>> DeleteNotification(int Id)
        {
            try
            {
                var data = await _notificationRepository.GetByIdAsync(Id);
                if (data == null)
                {
                    return await Result<int>.FailAsync("Data Not Found");
                }
                else
                {
                    await _notificationRepository.DeleteAsync(data);
                    return await Result<int>.SuccessAsync("Data Deleted");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public async Task<List<Trade>> GetTrades()
        {
            try
            {
                var data = await _tradeRepository.GetAllAsync();
                return data.ToList();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<Result<int>> InsertTrade(Trade trade)
        {
            try
            {
                await _tradeRepository.AddAsync(trade);
                return await Result<int>.SuccessAsync(trade.Id, "Trade Added");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<int>> UpdateTrade(Trade trade)
        {
            try
            {
                await _tradeRepository.UpdateAsync(trade);
                return await Result<int>.SuccessAsync(trade.Id, " Updated");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<int>> DeleteTrade(int Id)
        {
            try
            {
                var data = await _tradeRepository.GetByIdAsync(Id);
                if (data == null)
                {
                    return await Result<int>.FailAsync("Data Not Found");
                }
                else
                {
                    await _tradeRepository.DeleteAsync(data);
                    return await Result<int>.SuccessAsync("Data Deleted");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<Category>> GetCategories()
        {
            try
            {
                var data = await _categoryRepository.GetAllAsync();
                return data.ToList();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task<Result<int>> InsertCategory(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                return await Result<int>.SuccessAsync(category.Id, "Category Added");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<int>> UpdateCategory(Category category)
        {
            try
            {
                await _categoryRepository.UpdateAsync(category);
                return await Result<int>.SuccessAsync(category.Id, "Category Updated");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<int>> DeleteCategory(int Id)
        {
            try
            {
                var data = await _categoryRepository.GetByIdAsync(Id);
                if (data == null)
                {
                    return await Result<int>.FailAsync("Data Not Found");
                }
                else
                {
                    await _categoryRepository.DeleteAsync(data);
                    return await Result<int>.SuccessAsync("Data Deleted");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<SubCategory>> GetSubCategories()
        {
            try
            {

                var data = await _subcategoryRepository.GetAllAsync();
                return data.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Result<int>> InsertSubCategory(SubCategory subcategory)
        {
            await _subcategoryRepository.AddAsync(subcategory);
            return await Result<int>.SuccessAsync(subcategory.Id, "SubCategory Saved");
        }

        public async Task<Result<int>> UpdateSubCategory(SubCategory subcategory)
        {
            await _subcategoryRepository.UpdateAsync(subcategory);
            return await Result<int>.SuccessAsync(subcategory.Id, "SubCategory Update");
        }

        public async Task<Result<int>> DeleteSubCategory(int Id)
        {
            var data = await _subcategoryRepository.GetByIdAsync(Id);
            if (data == null)
            {
                return await Result<int>.FailAsync("SubCategory not found");
            }
            else
            {
                await _subcategoryRepository.DeleteAsync(data);
                return await Result<int>.SuccessAsync("SubCategory Deleted");
            }
        }


        public async Task<List<Post>> GetPosts()
        {
            try
            {

                var data = await _postRepository.GetAllAsync();
                return data.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Result<int>> InsertPost(Post post)
        {
            await _postRepository.AddAsync(post);
            return await Result<int>.SuccessAsync(post.Id, "Post is Saved");
        }

        public async Task<Result<int>> UpdatePost(Post post)
        {
            await _postRepository.UpdateAsync(post);
            return await Result<int>.SuccessAsync(post.Id, "Post is Update");
        }

        public async Task<Result<int>> DeletePost(int Id)
        {
            var data = await _postRepository.GetByIdAsync(Id);
            if (data == null)
            {
                return await Result<int>.FailAsync("Post is not found");
            }
            else
            {
                await _postRepository.DeleteAsync(data);
                return await Result<int>.SuccessAsync("Post is Deleted");
            }
        }




    }
}
