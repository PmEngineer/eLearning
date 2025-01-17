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
        public readonly IGenericRepository<BatchNote> _batchNotesRepository;
        IMapper _mapper;
        public BatchServiceAPI(IGenericRepository<BatchSubject> batchsubjectRepository, IMapper mapper, IGenericRepository<BatchNote> batchNotesRepository)
        {
            _batchsubjectRepository = batchsubjectRepository;
            _mapper = mapper;
            _batchNotesRepository = batchNotesRepository;
        }

        public async Task<Result<List<BatchNoteResponse>>> GetBatchNotes(int Id)
        {
            try
            {
                Expression<Func<BatchNote, bool>> Where=(x=>x.BatchId==Id);
                Expression<Func<BatchNote, object>>[] navigationProperties = new Expression<Func<BatchNote, object>>[] { x => x.Subject,y=>y.Batch };
                var data = await _batchNotesRepository.GetAllWithChildEntitiesAsync(Where,navigationProperties);
                var mappedBatchNotes = _mapper.Map<List<BatchNoteResponse>>(data);
                return await Result<List<BatchNoteResponse>>.SuccessAsync(mappedBatchNotes);
            }
            catch (Exception ex)
            {
                return await Result<List<BatchNoteResponse>>.FailAsync("Note Found Data");
            }
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
