using ELearning.Request;
using ELearning_Core.Model.Faculty;
using ELearning_Core.Shared;

namespace ELearning.Interface
{
    public interface IBatchService
    {
        public Task<List<BatchClass>> GetBatcheClasses();
        public Task<Result<int>> InsertBatchClass(BatchClass batchclass);
        public Task<Result<int>> UpdateBatchClass(BatchClass batchclass);
        public Task<Result<int>> DeleteBatchClass(int Id);
    }
}
