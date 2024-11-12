using AutoMapper;
using ELearning.Interface;
using ELearning.Request;
using ELearning.Response;
using ELearning_Core.Core.Model;
using ELearning_Core.Model.City;
using ELearning_Core.Model.Master;
using ELearning_Core.Model;
using ELearning_Core.Model.Student;
using ELearning_Core.Shared;

namespace ELearning.API
{
    public class StudentServiceAPI:IStudentServiceAPI
    {
        public readonly IGenericRepository<StudentInfo> _studentInfoRepository;
        public IMapper _mapper;
        public StudentServiceAPI(IMapper mapper,  IGenericRepository<StudentInfo> studentInfoRepository)
        {
           
            _studentInfoRepository = studentInfoRepository;
            _mapper = mapper;
        }
        public async Task<Result<int>> InsertStudentInfo(StudentInfoRequest studentInfoRequest)
        {
            var data = _mapper.Map<StudentInfo>(studentInfoRequest);
            try
            {
                await _studentInfoRepository.AddAsync(data);
                return await Result<int>.SuccessAsync(data.Id, "StudentInfo is Added.");
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync("StudentInfo is not Added." + ex.Message);
            }
        }
        public async Task<Result<StudentInfoResponse>> GetStudentByNameAndPassword(StudentInfoResponse studentInfoResponse)
        {
            try
            {

                var data = await _studentInfoRepository.GetAllAsync(x => x.Name == studentInfoResponse.Name && x.Password == studentInfoResponse.Password);
                var mappedData = _mapper.Map<StudentInfoResponse>(data.FirstOrDefault());
                if (mappedData == null)
                {
                    return await Result<StudentInfoResponse>.FailAsync("Login Failed");
                }
                else
                {
                    return await Result<StudentInfoResponse>.SuccessAsync(mappedData, "Login Successfully");
                }
            }

            catch (Exception ex)
            {
                return await Result<StudentInfoResponse>.FailAsync("StudentInfo failed to load." + ex.Message);
            }
        }

    }
}
