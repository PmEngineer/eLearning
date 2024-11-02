using ELearning.Profiles;
using ELearning.Request;
using ELearning.Response;
using ELearning_Core.Model;
using ELearning_Core.Model.Master;
using ELearning_Core.Shared;

namespace ELearning.API
{
    public interface IMasterServiceAPI
    {
        public Task<Result<List<Subject>>> GetSubjectsList();
        public Task<Result<List<CourseResponse>>> GetCourseList();
        public Task<Result<List<Lessons>>> GetLessonist(int Subid);

        public Task<Result<List<DoubtResponse>>> GetDoubtsList();
        public Task<Result<int>> InsertDoubt(DoubtRequest doubt);
        public Task<Result<int>> UpdateDoubt(DoubtRequest doubt);

        public Task<Result<List<DoubtCommentResponse>>> GetDoubtComment();
        public Task<Result<int>> InsertDoubtComment(DoubtCommentResponse doubtComment);
        public Task<Result<List<DoubtCommentResponse>>> GetComment(int DoubtId);
        public Task<Result<List<DoubtCommentResponse>>> GetComments(string UserId, int DoubtId);
      

        

    }
}


