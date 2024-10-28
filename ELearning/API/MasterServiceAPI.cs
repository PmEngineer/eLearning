using ELearning.Interface;
using ELearning.Response;
using ELearning_Core.Core.Model;
using ELearning_Core.Model;
using ELearning_Core.Model.City;
using ELearning_Core.Model.Master;
using ELearning_Core.Shared;

namespace ELearning.API
{
    public class MasterServiceAPI : IMasterServiceAPI
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
        public readonly IGenericRepository<Doubt> _doubtRepository;
        public readonly IGenericRepository<DoubtComment> _doubtCommentRepository;
        public MasterServiceAPI(IGenericRepository<Company> companyRepository, IGenericRepository<Country> countryRepository, IGenericRepository<State> stateRepository, IGenericRepository<City> cityRepository, IGenericRepository<Subject> subjectRepository, IGenericRepository<Lessons> lessonRepository, IGenericRepository<MainMenu> menuRepository, IGenericRepository<SubMenu> subMenuRepository, IGenericRepository<Course> courseRepository, IGenericRepository<Doubt> doubtRepository, IGenericRepository<DoubtComment> doubtCommentRepository)
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
            _doubtRepository = doubtRepository;
            _doubtCommentRepository = doubtCommentRepository;
        }

        public async Task<Result<List<CourseResponse>>> GetCourseList()
        {
            try
            {
                var data = await _courseRepository.GetAllAsync();
                List<CourseResponse> courseList = new List<CourseResponse>();   
                foreach (var item in data)
                {
                    CourseResponse course  =   new CourseResponse();
                    course.Id = item.Id;
                    course.Name = item.Name;    
                    courseList.Add(course);
                }
                return await Result<List<CourseResponse>>.SuccessAsync(courseList);
            }
            catch (Exception ex)
            { 
                throw;
            }
        }

        public Task<Result<List<Lessons>>> GetLessonist(int Subid)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<List<Subject>>> GetSubjectsList()
        {
            try
            {
                //  List<Subject> subjects = new List<Subject>();
                var data = await _subjectRepository.GetAllAsync();
                //subjects = data.ToList();
                return await Result<List<Subject>>.SuccessAsync(data.ToList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Result<List<Doubt>>> GetDoubtsList()
        {
            try
            {
              var data=  await _doubtRepository.GetAllAsync();
                return await Result<List<Doubt>>.SuccessAsync(data.ToList());
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Result<int>> InsertDoubt(Doubt doubt)
        {
            await _doubtRepository.AddAsync(doubt);
            return await Result<int>.SuccessAsync(doubt.Id, "Doubt is Added.");
        }

        public async Task<Result<List<DoubtComment>>> GetDoubtComment()
        {
            try
            {
                var data=await _doubtCommentRepository.GetAllAsync();
                return await Result<List<DoubtComment>>.SuccessAsync(data.ToList()); 
            }

            catch (Exception ex) {
                throw ex;
            }
        }
        public async Task<Result<int>> InsertDoubtComment(DoubtComment doubtComment)
        {
            await _doubtCommentRepository.AddAsync(doubtComment);
            return await Result<int>.SuccessAsync(doubtComment.Id, "Doubt is Added.");
        }
    }
}
