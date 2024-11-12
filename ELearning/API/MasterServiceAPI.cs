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
        public readonly IGenericRepository<DoubtLike> _doubtlikeRepository;
        public IMapper _mapper;
        public MasterServiceAPI(IMapper mapper, IGenericRepository<Company> companyRepository, IGenericRepository<Country> countryRepository, IGenericRepository<State> stateRepository, IGenericRepository<City> cityRepository, IGenericRepository<Subject> subjectRepository, IGenericRepository<Lessons> lessonRepository, IGenericRepository<MainMenu> menuRepository, IGenericRepository<SubMenu> subMenuRepository, IGenericRepository<Course> courseRepository, IGenericRepository<Doubt> doubtRepository, IGenericRepository<DoubtComment> doubtCommentRepository, IGenericRepository<DoubtLike> doubtlikeRepository)
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
            _doubtlikeRepository = doubtlikeRepository;
        }
        #region Course Subject

        public async Task<Result<List<CourseResponse>>> GetCourseList()
        {
            try
            {
                var data = await _courseRepository.GetAllAsync();
                List<CourseResponse> courseList = new List<CourseResponse>();
                foreach (var item in data)
                {
                    CourseResponse course = new CourseResponse();
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
                var data = await _doubtRepository.GetAllAsync();
                return await Result<List<Doubt>>.SuccessAsync(data.ToList());
            }
            catch (Exception ex)
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
                var data = await _doubtCommentRepository.GetAllAsync();
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

        #endregion

        #region Doubt
        public async Task<Result<List<DoubtResponse>>> GetDoubtsList(int subjectId)
        {
            try
            {
                if (subjectId == 0)
                {
                    var data = await _doubtRepository.GetAllAsync();

                    var mappedData = _mapper.Map<List<DoubtResponse>>(data.ToList());

                    return await Result<List<DoubtResponse>>.SuccessAsync(mappedData);
                }
                else
                {
                    var data = await _doubtRepository.GetAllAsync(X => X.SubjectId == subjectId);

                    var mappedData = _mapper.Map<List<DoubtResponse>>(data.ToList());

                    return await Result<List<DoubtResponse>>.SuccessAsync(mappedData);
                }
            }
            catch (Exception ex)
            {
                return await Result<List<DoubtResponse>>.FailAsync("DoubtResponse is failed. " + ex.Message);
            }
        }

        public async Task<Result<List<DoubtResponse>>> GetDoubts(string userName)
        {
            try
            {
                var data = await _doubtRepository.GetAllAsync(x => x.CreatedBy == userName);

                var mappedData = _mapper.Map<List<DoubtResponse>>(data.ToList());

                return await Result<List<DoubtResponse>>.SuccessAsync(mappedData);

            }
            catch (Exception ex)
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

        public async Task<Result<int>> UpdateDoubt(DoubtRequest doubt)
        {


            try
            {
                var data = await _doubtRepository.GetByIdAsync(doubt.Id);

                if (data != null)
                {
                    data.UpdatedDate = DateTime.Now;
                    data.Solution = doubt.Solution;
                    data.Description = doubt.Description;
                    // var updateDoubt = _mapper.Map<Doubt>(doubt);
                    await _doubtRepository.UpdateAsync(data);
                    return await Result<int>.SuccessAsync(data.Id, "Doubt is Updated.");
                }
                else
                {
                    return await Result<int>.FailAsync("Doubt not found.");
                }



            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync("Doubt is failed to Updated." + ex.Message);

            }

        }

        public async Task<Result<int>> DeleteDoubt(int Id)
        {
            var data = await _doubtRepository.GetByIdAsync(Id);

            try
            {
                if (data == null)
                {
                    return await Result<int>.FailAsync("Doubt not Found.");
                }
                else
                {
                    await _doubtRepository.DeleteAsync(data);
                    return await Result<int>.SuccessAsync("Doubt Deleted.");
                }
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync("Doubt is failed to Delete." + ex.Message);
            }
        }
        #endregion

        #region DoubtComment
        public async Task<Result<List<DoubtCommentResponse>>> GetAllDoubtComment(int Id)
        {
            try
            {
                var data = await _doubtCommentRepository.GetAllAsync(x => x.DoubtId == Id);
                var mappedData = _mapper.Map<List<DoubtCommentResponse>>(data.ToList());

                return await Result<List<DoubtCommentResponse>>.SuccessAsync(mappedData);
            }

            catch (Exception ex)
            {
                return await Result<List<DoubtCommentResponse>>.FailAsync("DoubtComment failed to load." + ex.Message);
            }
        }
        public async Task<Result<int>> InsertDoubtComment(DoubtCommentResponse doubtComment)
        {
            var data = _mapper.Map<DoubtComment>(doubtComment);
            try
            {
                await _doubtCommentRepository.AddAsync(data);
                var GetDoubt = await _doubtRepository.GetByIdAsync(doubtComment.DoubtId);
                GetDoubt.TotalComment = GetDoubt.TotalComment + 1;
                await _doubtRepository.UpdateAsync(GetDoubt);
                return await Result<int>.SuccessAsync(data.Id, "DoubtComment is Added.");
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync("DoubtComment is not Added." + ex.Message);
            }
        }

      
        //public async Task<Result<List<DoubtCommentResponse>>> GetComment(int Id)
        //{
        //    try
        //    {
        //        var data = await _doubtCommentRepository. (x => x.Id == Id);
        //        var mappedData = _mapper.Map<List<DoubtCommentResponse>>(data.ToList());
        //        return await Result<List<DoubtCommentResponse>>.SuccessAsync(mappedData);
        //    }

        //    catch (Exception ex)
        //    {
        //        return await Result<List<DoubtCommentResponse>>.FailAsync("Comment is failed to load By Id" + ex.Message);
        //    }

        //}


        public async Task<Result<int>> UpdateDoubtComment(DoubtCommentRequest request)
        {


            try
            {
                var data =await _doubtCommentRepository.GetByIdAsync(request.Id);

                if (data != null)
                {
                    data.UpdatedDate = DateTime.Now;
                    data.Comment = request.Comment;
                   // var updateDoubt = _mapper.Map<DoubtComment>(doubtComment);
                    await _doubtCommentRepository.UpdateAsync(data);
                    return await Result<int>.SuccessAsync(data.Id, "DoubtComment is Updated.");
                }
                else
                {
                    return await Result<int>.FailAsync("DoubtComment not found.");
                }



            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync("DoubtComment is failed to Updated." + ex.Message);

            }

        }
        public async Task <Result<int>> DeleteDoubtComment(int Id)
        {
            var data = await _doubtCommentRepository.GetByIdAsync(Id);
            try
            {
                if (data == null)
                {
                    return await Result<int>.FailAsync("DoubtComment not Found.");
                }
                else
                {
                    await _doubtCommentRepository.DeleteAsync(data);
                    return await Result<int>.SuccessAsync("DoubtComment deleted.");
                }
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync("DoubtComment is failed to Delete." + ex.Message);
            }

        }
        #endregion

        #region isLike
        public async Task<Result<int>> IsLike(DoubtLikeRequest doubtLike)

        {
            var data = _mapper.Map<DoubtLike>(doubtLike);
            try 
            {
                if (doubtLike.isLike==1)
                {
                    await _doubtlikeRepository.AddAsync(data);
                    var GetLike = await _doubtRepository.GetByIdAsync(doubtLike.DoubtId);
                    GetLike.TotalLike = GetLike.TotalLike + 1;
                    await _doubtRepository.UpdateAsync(GetLike);
                    return await Result<int>.SuccessAsync(doubtLike.DoubtId, "Like is added.");
                }
                else
                {
                   
                    var GetLike = await _doubtRepository.GetByIdAsync(doubtLike.DoubtId);
                    GetLike.TotalLike = GetLike.TotalLike - 1;
                    await _doubtRepository.UpdateAsync(GetLike);
                    return await Result<int>.SuccessAsync(doubtLike.DoubtId, "Like is removed.");
                }
                
            }
            catch(Exception ex) 
            {

                return await Result<int>.FailAsync("Doubt Like is Failed." + ex.InnerException.Message);
            }

        }
        #endregion
    }
}
