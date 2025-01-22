using ELearning.Request;
using ELearning_Core.Model.Faculty;
using ELearning_Core.Shared;

namespace ELearning.Interface
{
    public interface IBatchService
    {
        #region BatchClass
        public Task<List<BatchClass>> GetBatcheClasses();
        public Task<Result<int>> InsertBatchClass(BatchClass batchclass);
        public Task<Result<int>> UpdateBatchClass(BatchClass batchclass);
        public Task<Result<int>> DeleteBatchClass(int Id);
        #endregion

        #region Batch Notes
        public Task<List<BatchNote>> GetBatchNotes();
        public Task<Result<int>> InsertBatchNote(BatchNote batchnote);
        public Task<Result<int>> UpdateBatchNote(BatchNote batchnote);
        public Task<Result<int>> DeleteBatchNote(int Id);
        #endregion
    }
}
