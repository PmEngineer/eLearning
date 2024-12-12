using ELearning.Request;
using ELearning.Response;
using ELearning_Core.Model.Student;
using ELearning_Core.Shared;

namespace ELearning.API
{
    public interface IStudentServiceAPI
    {
        #region StudentInfo
        public Task<Result<int>> InsertStudentInfo(StudentInfoRequest studentInfoRequest);
        public Task<Result<StudentInfoResponse>> GetStudentByNameAndPassword(StudentLoginRequest studentLoginRequest);
        public Task<StudentInfoRequest> FindByEmailAsync(ForgotPasswordRequest resetPasswordRequest);
        public Task<Result<int>> UpdateStudentInfo(StudentInfoRequest studentInfoRequest);
        #endregion

    }
}
