using AutoMapper;
using ELearning.Interface;
using ELearning.Response;
using ELearning_Core.Model.Faculty;
using ELearning_Core.Shared;

namespace ELearning.Services
{
    public class BatchService : IBatchService
    {
        public readonly IGenericRepository<BatchClass> _batchclassRepository;
        IMapper _mapper;
        public BatchService(IGenericRepository<BatchClass> batchclassRepository, IMapper mapper)
        {
            _batchclassRepository = batchclassRepository;
            _mapper = mapper;
        }
        public async Task<List<BatchClass>> GetBatcheClasses()
        {
            try
            {
                var data = await _batchclassRepository.GetAllAsync();
                return data.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<Result<int>> InsertBatchClass(BatchClass batchclass)
        {
            try
            {
                await _batchclassRepository.AddAsync(batchclass);
                return await Result<int>.SuccessAsync(batchclass.Id, "Class added successfully..");
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }
        public async Task<Result<int>> UpdateBatchClass(BatchClass batchclass)
        {
            try
            {
                await _batchclassRepository.UpdateAsync(batchclass);
                return await Result<int>.SuccessAsync(batchclass.Id, "Class Updated Succesfully...");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Result<int>> DeleteBatchClass(int Id)
        {
            var data = await _batchclassRepository.GetByIdAsync(Id);
            if (data == null)
            {
                return await Result<int>.FailAsync("Class Id is not Found....");
            }
            else
            {
                await _batchclassRepository.DeleteAsync(data);
                return await Result<int>.SuccessAsync("Class Deleted Successfully...");
            }
        }


    }
}
