using AutoMapper;
using ELearning.Interface;
using ELearning.Response;
using ELearning_Core.Model.Faculty;
using ELearning_Core.Model.Master;
using ELearning_Core.Shared;
using System.Linq.Expressions;

namespace ELearning.API
{
    public class BatchServiceAPI : IBatchServiceAPI
    {
        public readonly IGenericRepository<BatchSubject> _batchsubjectRepository;
        IMapper _mapper;
        public BatchServiceAPI(IGenericRepository<BatchSubject> batchsubjectRepository, IMapper mapper)
        {
            _batchsubjectRepository = batchsubjectRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<BatchSubjectResponse>>> GetBatchSubject(int Id)
        {
            try {
                Expression<Func<BatchSubject, bool>> Where = (x=>x.BatchId==Id);
                Expression<Func<BatchSubject, object>>[] navigationProperties = new Expression<Func<BatchSubject, object>>[] { x => x.Subject, y => y.Faculty };
                var subjectData = await _batchsubjectRepository.GetAllWithChildEntitiesAsync(Where, navigationProperties);
                     var mappedData = _mapper.Map<List<BatchSubjectResponse>>(subjectData);
                     return await Result<List<BatchSubjectResponse>>.SuccessAsync(mappedData);
                
            }
            catch (Exception ex)
            {
                return await Result<List<BatchSubjectResponse>>.FailAsync("Subject Failed to load.." + ex.Message);
            }
        }
    }


}
