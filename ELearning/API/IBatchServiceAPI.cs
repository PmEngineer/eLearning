using ELearning.Response;
using ELearning_Core.Shared;

namespace ELearning.API
{
    public interface IBatchServiceAPI
    {
        #region BatchSubject
        public Task<Result<List<BatchSubjectResponse>>> GetBatchSubject(int Id);
        #endregion
    }
}
