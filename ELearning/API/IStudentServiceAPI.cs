using ELearning.Request;
using ELearning.Response;
using ELearning_Core.Shared;

namespace ELearning.API
{
    public interface IStudentServiceAPI
    {
        #region StudentInfo
        public Task<Result<int>> InsertStudentInfo(StudentInfoRequest studentInfoRequest);
        public Task<Result<StudentInfoResponse>> GetStudentByNameAndPassword(StudentInfoResponse studentInfoResponse);

        #endregion

    }
}
