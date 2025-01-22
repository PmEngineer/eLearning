using ELearning.Response;
using ELearning_Core.Model.Quiz;
using ELearning_Core.Shared;

namespace ELearning.API
{
    public interface IBatchServiceAPI
    {
        #region BatchSubject
        public Task<Result<List<BatchSubjectResponse>>> GetBatchSubject(int Id);
        #endregion

        #region BatchClass
        public Task<Result<List<BatchClassResponse>>> GetBatchClass(int Bid,int Sid);
        #endregion

        #region BatchNote
        public Task<Result<List<BatchNoteResponse>>> GetBatchNotes(int Bid,int Sid );

        #endregion

        #region BatchQuiz
        public Task<Result<List<BatchQuizResponse>>> GetQuizResponses(int Bid,int Sid);
        #endregion

    }
}
