using AutoMapper;
using ELearning.Interface;
using ELearning.Request;
using ELearning.Response;
using ELearning_Core.Model.Faculty;
using ELearning_Core.Model.Quiz;
using ELearning_Core.Shared;

namespace ELearning.Services
{
    public class BatchService : IBatchService
    {
        public readonly IGenericRepository<BatchClass> _batchclassRepository;
        public readonly IGenericRepository<BatchNote>  _batchnoteRepository;
        public readonly IGenericRepository<BatchQuiz>  _batchquizRepository;
        public readonly IGenericRepository<QuizOption> _quizoptionRepository;
        IMapper _mapper;
        public BatchService(IGenericRepository<BatchClass> batchclassRepository, IMapper mapper, IGenericRepository<BatchNote> batchnoteRepository, IGenericRepository<BatchQuiz> batchquizRepository, IGenericRepository<QuizOption> quizoptionRepository)
        {
            _batchclassRepository = batchclassRepository;
            _mapper = mapper;
            _batchnoteRepository = batchnoteRepository;
            _batchquizRepository = batchquizRepository;
            _quizoptionRepository = quizoptionRepository;
              
        }
        #region Batch Class
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
        #endregion

        #region Batch Notes
        public async Task<List<BatchNote>> GetBatchNotes()
        {
            try
            {
                var data=await _batchnoteRepository.GetAllAsync();
                return data.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Result<int>> InsertBatchNote(BatchNote batchnote)
        {
            try
            {
                await _batchnoteRepository.AddAsync(batchnote);
                return await Result<int>.SuccessAsync(batchnote.Id, "Batch's Note added Succesfully...");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Result<int>> UpdateBatchNote(BatchNote batchnote)
        {
            try
            {
                await _batchnoteRepository.UpdateAsync(batchnote);
                return await Result<int>.SuccessAsync(batchnote.Id, "Batch's Note Updated Successfully..");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Result<int>> DeleteBatchNote(int Id)
        {
            var data = await _batchnoteRepository.GetByIdAsync(Id);
                if (data == null)
            {
               
                return await Result<int>.FailAsync("Batch's Note is not found");
            }
            else
            {
                await _batchnoteRepository.DeleteAsync(data);
                return await Result<int>.SuccessAsync("Batch's Note deleted succesfully... ");
            }

        }
        #endregion

        #region BatchQuiz
        public async Task<List<BatchQuiz>> GetQuizzes()
        {
            try
            {
                var data = await _batchquizRepository.GetAllAsync();
                return data.ToList();
            }
            catch (Exception ex) 
            
            {
                throw ex;   
            }

         
        }
        public async Task<Result<int>> InsertQuiz(BatchQuizRequest batchquiz)
        {
            try
            {

               var data=_mapper.Map<BatchQuiz>(batchquiz);

                if (data.QuestionType == 3)
                {
                    data.CreatedDate = DateTime.Now;
                    var quizData = await _batchquizRepository.AddAsync(data);
                }
                else
                {
                    data.CreatedDate = DateTime.Now;
                    var quizData = await _batchquizRepository.AddAsync(data);

                    var quizOptions = _mapper.Map<List<QuizOption>>(batchquiz.QuizOptions);
                    quizOptions.Select(x => { x.CreatedBy = quizData.CreatedBy; return x; }).ToList();
                    quizOptions.Select(x => { x.CreatedDate = quizData.CreatedDate; return x; }).ToList();
                    quizOptions.Select(x => { x.BatchQuizId = quizData.Id; return x; }).ToList();

                    await _quizoptionRepository.BulkAddAsync(quizOptions);
                }
              
                return await Result<int>.SuccessAsync(data.Id, "Quiz Question Added Successfully");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Result<int>> UpdateQuiz(BatchQuiz batchquiz)
        {
            try
            {
                await _batchquizRepository.UpdateAsync(batchquiz);
                return await Result<int>.SuccessAsync(batchquiz.Id, "Quiz Question Updated Successfuuly...");
            }
            catch (Exception ex) 
            {
                throw ex;
            }

        }
        public async Task<Result<int>> DeleteQuiz(int Id)
        {
            var data=await _batchquizRepository.GetByIdAsync(Id);
            if (data == null)
            {
                return await Result<int>.FailAsync("Quiz Not Found...");
            }
            else
            {
                await _batchquizRepository.DeleteAsync(data);
                return await Result<int>.SuccessAsync("Quiz Deleted Successfully...");
            }
        }
        #endregion
    }
}
