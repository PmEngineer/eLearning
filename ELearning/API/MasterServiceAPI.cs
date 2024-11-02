using AutoMapper;
using ELearning.Interface;
using ELearning.Migrations;
using ELearning.Request;
using ELearning.Response;
using ELearning_Core.Core.Model;
using ELearning_Core.Model;
using ELearning_Core.Model.City;
using ELearning_Core.Model.Master;
using ELearning_Core.Shared;
using Humanizer;
using System;

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
        public IMapper _mapper;
        public MasterServiceAPI(IMapper mapper, IGenericRepository<Company> companyRepository, IGenericRepository<Country> countryRepository, IGenericRepository<State> stateRepository, IGenericRepository<City> cityRepository, IGenericRepository<Subject> subjectRepository, IGenericRepository<Lessons> lessonRepository, IGenericRepository<MainMenu> menuRepository, IGenericRepository<SubMenu> subMenuRepository, IGenericRepository<Course> courseRepository, IGenericRepository<Doubt> doubtRepository, IGenericRepository<DoubtComment> doubtCommentRepository)
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
            _mapper = mapper;
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
        public async Task<Result<List<DoubtResponse>>> GetDoubtsList()
        {
            try
            {
              var data=  await _doubtRepository.GetAllAsync();
                var mappedData = _mapper.Map<List<DoubtResponse>>(data.ToList());

                return await Result<List<DoubtResponse>>.SuccessAsync(mappedData);
            }
            catch(Exception ex)
            {
                return await Result<List<DoubtResponse>>.FailAsync("DoubtResponse is failed. " + ex.Message);
            }
        }
        public async Task<Result<int>> InsertDoubt(DoubtRequest doubt)
        {
           var data = _mapper.Map<Doubt>(doubt);
            try
            {
                await _doubtRepository.AddAsync(data);
                return await Result<int>.SuccessAsync(data.Id, "Doubt is Added.");
            }
            catch (Exception e)
            {
                return await Result<int>.FailAsync("Doubt is Not Added. " + e.Message);
            }
        }

        public async Task<Result<List<DoubtCommentResponse>>> GetDoubtComment()
        {
            try
            {
                var data = await _doubtCommentRepository.GetAllAsync();
                var mappedData = _mapper.Map<List<DoubtCommentResponse>>(data.ToList());

                return await Result<List<DoubtCommentResponse>>.SuccessAsync(mappedData);
            }

            catch (Exception ex) {
                return await Result<List<DoubtCommentResponse>>.FailAsync("DoubtComment failed to load" + ex.Message);
            }
        }
        public async Task<Result<int>> InsertDoubtComment(DoubtCommentResponse doubtComment)
        {
            var data = _mapper.Map<DoubtComment>(doubtComment);
            try { 
            await _doubtCommentRepository.AddAsync(data);
            return await Result<int>.SuccessAsync(data.Id, "DoubtComment is Added.");
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync("DoubtComment is not Added."+ ex.Message);
            }
        }

        public async Task<Result<List<DoubtCommentResponse>>> GetComment(int DoubtId)
        {
            try
            {
                var data = await _doubtCommentRepository.GetAllAsync(x=>x.DoubtId==DoubtId);
           var mappedData = _mapper.Map<List<DoubtCommentResponse>>(data.ToList());
                return await Result<List<DoubtCommentResponse>>.SuccessAsync(mappedData);
            }

            catch (Exception ex)
            {
                return await Result<List<DoubtCommentResponse>>.FailAsync("Comment is failed to load By Id" + ex.Message);
            }
               
        }
        public async Task<Result<List<DoubtCommentResponse>>> GetComments(string UserId, int DoubtId)
        {
            try
            {
                var data = await _doubtCommentRepository.GetAllAsync(x=>x.DoubtId == DoubtId && x.CreatedBy==UserId);
                var mappedData =_mapper.Map<List<DoubtCommentResponse>>(data.ToList());
                return await Result<List<DoubtCommentResponse>>.SuccessAsync(mappedData);
            }

            catch (Exception ex)
            {
                return await Result<List<DoubtCommentResponse>>.FailAsync("Comment is failed to load by USer and Doubt Id" + ex.Message);
            }
        }
        public async Task<Result<int>> UpdateDoubt(DoubtRequest doubt)
        {
           
            
            try
            {
                var data = _doubtRepository.GetByIdAsync(doubt.Id);

                if (data != null)
                {
          
                    var updateDoubt = _mapper.Map<Doubt>(doubt);
                    await _doubtRepository.UpdateAsync(updateDoubt);
                    return await Result<int>.SuccessAsync(data.Id, "Doubt is Updated");
                }
                else
                {
                    return await Result<int>.FailAsync("Doubt not found");
                }

                

            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync("Doubt is failed to Updated" + ex.Message);

            }

        }


    }
}
