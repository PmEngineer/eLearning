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
        public readonly IGenericRepository<BatchClass> _batchclassRepository;
        IMapper _mapper;
        public BatchServiceAPI(IGenericRepository<BatchSubject> batchsubjectRepository, IMapper mapper, IGenericRepository<BatchClass> batchclassRepository)
        {
            _batchsubjectRepository = batchsubjectRepository;
            _mapper = mapper;
            _batchclassRepository = batchclassRepository;
        }

        #region BatchSubject
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
        #endregion

        #region BatchClass
        public async Task<Result<List<BatchClassResponse>>> GetBatchClass(int Bid, int Sid)
        {
            try
            {
                Expression<Func<BatchClass, bool>> Where;

                if (Sid == 0)
                {
                   
                    Where = x => x.BatchId == Bid;
                }
                else
                {
                   
                    Where = x => x.BatchId == Bid && x.SubjectId == Sid;
                }
                Expression<Func<BatchClass, object>>[] navigationProperties = new Expression<Func<BatchClass, object>>[] { x => x.Batch, y => y.Subject };
                var data = await _batchclassRepository.GetAllWithChildEntitiesAsync(Where, navigationProperties);
                var mappedData = _mapper.Map<List<BatchClassResponse>>(data.ToList());
                return await Result<List<BatchClassResponse>>.SuccessAsync(mappedData);
            }
            catch (Exception ex)
            {
                return await Result<List<BatchClassResponse>>.FailAsync("Subject Failed to Load...." + ex.Message);
            }
        }
        #endregion
    }


}
