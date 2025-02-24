using AutoMapper;
using ELearning.Interface;
using ELearning.Request;
using ELearning.Response;
using ELearning_Core.Model.Faculty;
using ELearning_Core.Model.Master;
using ELearning_Core.Model.Quiz;
using ELearning_Core.Shared;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace ELearning.API
{
    public class BatchServiceAPI : IBatchServiceAPI
    {
        public readonly IGenericRepository<BatchSubject> _batchsubjectRepository;
        public readonly IGenericRepository<BatchClass> _batchclassRepository;
        public readonly IGenericRepository<BatchNote> _batchNotesRepository;
        public readonly IGenericRepository<BatchQuiz> _batchquizRepository;
        public readonly IGenericRepository<QuizOption> _quizOptionRepository;
        public readonly IGenericRepository<QuizAnswer> _quizAnswerRepositor;
        IMapper _mapper;
        public BatchServiceAPI
            (
            IMapper mapper,
            IGenericRepository<BatchSubject> batchsubjectRepository,
            IGenericRepository<BatchClass> batchclassRepository,
            IGenericRepository<BatchNote> batchNotesRepository,
            IGenericRepository<BatchQuiz> batchquizRepository,
            IGenericRepository<QuizOption> quizOptionRepository,
            IGenericRepository<QuizAnswer> quizAnswerRepository
            )
        {

            _mapper = mapper;
            _batchsubjectRepository = batchsubjectRepository;
            _batchclassRepository = batchclassRepository;
            _batchNotesRepository = batchNotesRepository;
            _batchquizRepository = batchquizRepository;
            _quizOptionRepository = quizOptionRepository;
            _quizAnswerRepositor = quizAnswerRepository;
        }

        #region BatchSubject
        public async Task<Result<List<BatchSubjectResponse>>> GetBatchSubject(int Id)
        {
            try
            {
                Expression<Func<BatchSubject, bool>> Where = (x => x.BatchId == Id);
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

        #region BatchNotes
        public async Task<Result<List<BatchNoteResponse>>> GetBatchNotes(int Bid, int Sid)
        {
            try
            {

                Expression<Func<BatchNote, bool>> Where;

                if (Sid == 0)
                {

                    Where = x => x.BatchId == Bid;
                }
                else
                {

                    Where = x => x.BatchId == Bid && x.SubjectId == Sid;
                }
                Expression<Func<BatchNote, object>>[] navigationProperties = new Expression<Func<BatchNote, object>>[] { x => x.Subject, y => y.Batch };
                var data = await _batchNotesRepository.GetAllWithChildEntitiesAsync(Where, navigationProperties);

                var mappedBatchNotes = _mapper.Map<List<BatchNoteResponse>>(data);
                mappedBatchNotes.Select(x => { x.NoteFile = "BatchNote/Documents/" + x.NoteFile; return x; }).ToList();
                return await Result<List<BatchNoteResponse>>.SuccessAsync(mappedBatchNotes);
            }
            catch (Exception ex)
            {
                return await Result<List<BatchNoteResponse>>.FailAsync("Note not Found Data");
            }
        }
        #endregion

        #region BatchQuiz
        public async Task<Result<List<BatchQuizResponse>>> GetQuizResponses(int Bid, int Sid)
        {
            try
            {

                Expression<Func<BatchQuiz, bool>> Where;

                if (Sid == 0)
                {

                    Where = x => x.BatchId == Bid;
                }
                else
                {

                    Where = x => x.BatchId == Bid && x.SubjectId == Sid;
                }
                Expression<Func<BatchQuiz, object>>[] navigationProperties = new Expression<Func<BatchQuiz, object>>[] { x => x.Subject, y => y.Batch };
                var data = await _batchquizRepository.GetAllWithChildEntitiesAsync(Where, navigationProperties);
                var mappedBatchNotes = _mapper.Map<List<BatchQuizResponse>>(data);

                var optiondata = await _quizOptionRepository.GetAllAsync();


                mappedBatchNotes.ForEach(x =>
                {

                    var data = optiondata.Where(y => y.BatchQuizId == x.Id).ToList();
                    var mappedBatchoption = _mapper.Map<List<QuizOptionResponse>>(data);
                    x.QuizOption =mappedBatchoption;

                });

  

                //var mapppedOptionData = _mapper.Map<List<QuizOption>>(optiondata);
                return await Result<List<BatchQuizResponse>>.SuccessAsync(mappedBatchNotes);
            }
            catch (Exception ex)
            {
                return await Result<List<BatchQuizResponse>>.FailAsync("Note not Found Data");
            }
        }
        #endregion

        #region QuizAnswer
        public async Task<Result<int>> InsertQuizAnswer(QuizAnswerRequest request)
        {
            var data = _mapper.Map<QuizAnswer>(request);

            
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));

            }
            if (request.QuestionType == 1)
            {
                if (request.OptionId == null)
                {

                    return await Result<int>.FailAsync(request.StudentId + "Answer is Not Selected. Please Select the Answer...");

                }
                else
                {
                    try
                    {
                        data.CreatedDate = DateTime.Now;
                        await _quizAnswerRepositor.AddAsync(data);
                        return await Result<int>.SuccessAsync(data.Id, "Answer for this Question saved Successfully..");
                    }
                    catch (Exception ex)
                    {
                        return await Result<int>.FailAsync("Answer is not saved." + ex.Message);
                    }
                }
            }
            else if (request.QuestionType == 3)
            {
                if (string.IsNullOrWhiteSpace(request.Answer))
                {
                    return await Result<int>.FailAsync(request.StudentId + "Answer is Not Filled. Please Fill the Answer...");
                }
                else
                {
                    data.CreatedDate = DateTime.Now;
                    await _quizAnswerRepositor.AddAsync(data);
                    return await Result<int>.SuccessAsync(data.Id, "Answer for this Question saved Successfully..");
                }

            }
            else
            {
                if (request.OptionId == null)
                {

                    return await Result<int>.FailAsync(request.StudentId + "Answer is Not Selected. Please Select the Answer...");

                }
                else
                {
                    try
                    {
                        foreach (var item in data.Answer)
                        {
                            data.CreatedDate = DateTime.Now;
                            await _quizAnswerRepositor.AddAsync(data);
                        }
                      
                        return await Result<int>.SuccessAsync(data.Id, "Answer for this Question saved Successfully..");
                    }
                    catch (Exception ex)
                    {
                        return await Result<int>.FailAsync("Answer is not saved." + ex.Message);
                    }
                }
            }

            return await Result<int>.SuccessAsync(request.StudentId + "Answer Saved Successfully...");
        }
        #endregion
    }
}

