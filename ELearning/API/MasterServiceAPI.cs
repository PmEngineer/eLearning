using AutoMapper;
using ELearning.Data;
using ELearning.Interface;
using ELearning.Migrations;
using ELearning.Request;
using ELearning.Response;
using ELearning_Core.Core.Model;
using ELearning_Core.Model;
using ELearning_Core.Model.City;
using ELearning_Core.Model.Faculty;
using ELearning_Core.Model.Master;
using ELearning_Core.Model.Student;
using ELearning_Core.Shared;
using Humanizer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace ELearning.API
{
    public class MasterServiceAPI : IMasterServiceAPI
    {
        public readonly IGenericRepository<Company> _companyRepository;
        public readonly IGenericRepository<Country> _countryRepository;
        public readonly IGenericRepository<State> _stateRepository;
        public readonly IGenericRepository<City> _cityRepository;
        public readonly IGenericRepository<Subject> _subjectRepository;
        public readonly IGenericRepository<Lessons> _lessonRepository;
        public readonly IGenericRepository<MainMenu> _menuRepository;
        public readonly IGenericRepository<SubMenu> _subMenuRepository;
        public readonly IGenericRepository<Course> _courseRepository;
        public readonly IGenericRepository<Doubt> _doubtRepository;
        public readonly IGenericRepository<DoubtComment> _doubtCommentRepository;
        public readonly IGenericRepository<DoubtLike> _doubtlikeRepository;
        public readonly IGenericRepository<PdfNote> _pdfNotesRepository;
        public readonly IGenericRepository<PreviousYearPaper> _paperRepository;
        public readonly IGenericRepository<Book> _bookRepository;
        public readonly IGenericRepository<Faculty> _facultyRepository;
        public readonly IGenericRepository<Category> _categoryRepository;
        public readonly IGenericRepository<SubCategory> _subcategoryRepository;
        public readonly IGenericRepository<HelpDesk> _helpDeskRepository;
        public readonly IGenericRepository<Batch> _batchRepositry;
        public readonly IGenericRepository<BatchSubject> _batchsubjectRepository;
        protected readonly ELearningContext _context;
        public IMapper _mapper;
        public MasterServiceAPI(IMapper mapper, IGenericRepository<Company> companyRepository, IGenericRepository<Country> countryRepository, IGenericRepository<State> stateRepository, IGenericRepository<City> cityRepository, IGenericRepository<Subject> subjectRepository, IGenericRepository<Lessons> lessonRepository, IGenericRepository<MainMenu> menuRepository, IGenericRepository<SubMenu> subMenuRepository, IGenericRepository<Course> courseRepository, IGenericRepository<Doubt> doubtRepository, IGenericRepository<DoubtComment> doubtCommentRepository, IGenericRepository<DoubtLike> doubtlikeRepository, IGenericRepository<PdfNote> pdfNotesRepository, IGenericRepository<PreviousYearPaper> paperRepository, IGenericRepository<Book> bookRepository, IGenericRepository<Faculty> facultyRepository, IGenericRepository<Category> categoryRepository, 
            IGenericRepository<SubCategory> subcategoryRepository, IGenericRepository<HelpDesk> helpDeskRepository,IGenericRepository<Batch> batchRepository, IGenericRepository<BatchSubject> batchsubjectRepository,    ELearningContext context)
        {
            _companyRepository = companyRepository;
            _countryRepository = countryRepository;
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
            _subjectRepository = subjectRepository;
            _lessonRepository = lessonRepository;
            _menuRepository = menuRepository;
            _subMenuRepository = subMenuRepository;
            _courseRepository = courseRepository;
            _doubtRepository = doubtRepository;
            _doubtCommentRepository = doubtCommentRepository;
            _pdfNotesRepository = pdfNotesRepository;
             _mapper = mapper;
            _doubtlikeRepository = doubtlikeRepository;
            _paperRepository = paperRepository;
            _bookRepository = bookRepository;
            _facultyRepository = facultyRepository;
            _categoryRepository = categoryRepository;
            _subcategoryRepository = subcategoryRepository;
            _helpDeskRepository = helpDeskRepository;
            _batchRepositry = batchRepository;
            _batchsubjectRepository = batchsubjectRepository;
            _context = context;
        }
        #region Course Subject

        public async Task<Result<List<CourseResponse>>> GetCourseList()
        {
            try
            {
                var data = await _courseRepository.GetAllAsync();
                List<CourseResponse> courseList = new List<CourseResponse>();
                foreach (var item in data)
                {
                    CourseResponse course = new CourseResponse();
                    course.Id = item.Id;
                    course.Name = item.Name;
                    courseList.Add(course);
                }
                return await Result<List<CourseResponse>>.SuccessAsync(courseList);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<Result<List<Lessons>>> GetLessonist(int Subid)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<List<Subject>>> GetSubjectsList()
        {
            try
            {
                //  List<Subject> subjects = new List<Subject>();
                var data = await _subjectRepository.GetAllAsync();
                //subjects = data.ToList();
                return await Result<List<Subject>>.SuccessAsync(data.ToList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Result<List<Doubt>>> GetDoubtsList()
        {
            try
            {
                var data = await _doubtRepository.GetAllAsync();
                return await Result<List<Doubt>>.SuccessAsync(data.ToList());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Result<int>> InsertDoubt(Doubt doubt)
        {
            doubt.CreatedDate = DateTime.Now;
            await _doubtRepository.AddAsync(doubt);
            return await Result<int>.SuccessAsync(doubt.Id, "Doubt is Added.");
        }

        public async Task<Result<List<DoubtComment>>> GetDoubtComment()
        {
            try
            {
                var data = await _doubtCommentRepository.GetAllAsync();
                return await Result<List<DoubtComment>>.SuccessAsync(data.ToList());
            }

            catch (Exception ex) {
                throw ex;
            }
        }
        public async Task<Result<int>> InsertDoubtComment(DoubtComment doubtComment)
        {
            doubtComment.CreatedDate = DateTime.Now;
            await _doubtCommentRepository.AddAsync(doubtComment);
            return await Result<int>.SuccessAsync(doubtComment.Id, "Doubt is Added.");
        }

        #endregion

        #region Doubt
        public async Task<Result<List<DoubtResponse>>> GetDoubtsList(int subjectId)
        {
            try
            {
                if (subjectId == 0)
                {
                    var data = await _doubtRepository.GetAllAsync();

                    var mappedData = _mapper.Map<List<DoubtResponse>>(data.ToList());

                    return await Result<List<DoubtResponse>>.SuccessAsync(mappedData);
                }
                else
                {
                    var data = await _doubtRepository.GetAllAsync(X => X.SubjectId == subjectId);

                    var mappedData = _mapper.Map<List<DoubtResponse>>(data.ToList());

                    return await Result<List<DoubtResponse>>.SuccessAsync(mappedData);
                }
            }
            catch (Exception ex)
            {
                return await Result<List<DoubtResponse>>.FailAsync("DoubtResponse is failed. " + ex.Message);
            }
        }

        public async Task<Result<List<DoubtResponse>>> GetDoubts(string userName)
        {
            try
            {
                var data = await _doubtRepository.GetAllAsync(x => x.CreatedBy == userName);

                var mappedData = _mapper.Map<List<DoubtResponse>>(data.ToList());

                return await Result<List<DoubtResponse>>.SuccessAsync(mappedData);

            }
            catch (Exception ex)
            {
                return await Result<List<DoubtResponse>>.FailAsync("DoubtResponse is failed. " + ex.Message);
            }
        }

        public async Task<Result<int>> InsertDoubt(DoubtRequest doubt)
        {
            var data = _mapper.Map<Doubt>(doubt);
            try
            {
                await _doubtRepository.AddAsync(data);
                return await Result<int>.SuccessAsync(data.Id, "Doubt is Added.");
            }
            catch (Exception e)
            {
                return await Result<int>.FailAsync("Doubt is Not Added. " + e.Message);
            }
        }

        public async Task<Result<int>> UpdateDoubt(DoubtRequest doubt)
        {


            try
            {
                var data = await _doubtRepository.GetByIdAsync(doubt.Id);

                if (data != null)
                {
                    data.UpdatedDate = DateTime.Now;
                    data.Solution = doubt.Solution;
                    data.Description = doubt.Description;
                    // var updateDoubt = _mapper.Map<Doubt>(doubt);
                    await _doubtRepository.UpdateAsync(data);
                    return await Result<int>.SuccessAsync(data.Id, "Doubt is Updated.");
                }
                else
                {
                    return await Result<int>.FailAsync("Doubt not found.");
                }



            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync("Doubt is failed to Updated." + ex.Message);

            }

        }

        public async Task<Result<int>> DeleteDoubt(int Id)
        {
            var data = await _doubtRepository.GetByIdAsync(Id);

            try
            {
                if (data == null)
                {
                    return await Result<int>.FailAsync("Doubt not Found.");
                }
                else
                {
                    await _doubtRepository.DeleteAsync(data);
                    return await Result<int>.SuccessAsync("Doubt Deleted.");
                }
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync("Doubt is failed to Delete." + ex.Message);
            }
        }
        #endregion

        #region DoubtComment
        public async Task<Result<List<DoubtCommentResponse>>> GetAllDoubtComment(int Id)
        {
            try
            {
                var data = await _doubtCommentRepository.GetAllAsync(x => x.DoubtId == Id);
                var mappedData = _mapper.Map<List<DoubtCommentResponse>>(data.ToList());

                return await Result<List<DoubtCommentResponse>>.SuccessAsync(mappedData);
            }

            catch (Exception ex)
            {
                return await Result<List<DoubtCommentResponse>>.FailAsync("DoubtComment failed to load." + ex.Message);
            }
        }
        public async Task<Result<int>> InsertDoubtComment(DoubtCommentResponse doubtComment)
        {
            var data = _mapper.Map<DoubtComment>(doubtComment);
            try
            {
                data.CreatedDate = DateTime.Now;
                await _doubtCommentRepository.AddAsync(data);
                var GetDoubt = await _doubtRepository.GetByIdAsync(doubtComment.DoubtId);
                GetDoubt.TotalComment = GetDoubt.TotalComment + 1;
                await _doubtRepository.UpdateAsync(GetDoubt);
                return await Result<int>.SuccessAsync(data.Id, "DoubtComment is Added.");
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync("DoubtComment is not Added." + ex.Message);
            }
        }

      
        //public async Task<Result<List<DoubtCommentResponse>>> GetComment(int Id)
        //{
        //    try
        //    {
        //        var data = await _doubtCommentRepository. (x => x.Id == Id);
        //        var mappedData = _mapper.Map<List<DoubtCommentResponse>>(data.ToList());
        //        return await Result<List<DoubtCommentResponse>>.SuccessAsync(mappedData);
        //    }

        //    catch (Exception ex)
        //    {
        //        return await Result<List<DoubtCommentResponse>>.FailAsync("Comment is failed to load By Id" + ex.Message);
        //    }

        //}


        public async Task<Result<int>> UpdateDoubtComment(DoubtCommentRequest request)
        {


            try
            {
                var data =await _doubtCommentRepository.GetByIdAsync(request.Id);

                if (data != null)
                {
                    data.UpdatedDate = DateTime.Now;
                    data.Comment = request.Comment;
                   // var updateDoubt = _mapper.Map<DoubtComment>(doubtComment);
                    await _doubtCommentRepository.UpdateAsync(data);
                    return await Result<int>.SuccessAsync(data.Id, "DoubtComment is Updated.");
                }
                else
                {
                    return await Result<int>.FailAsync("DoubtComment not found.");
                }



            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync("DoubtComment is failed to Updated." + ex.Message);

            }

        }
        public async Task <Result<int>> DeleteDoubtComment(int Id)
        {
            var data = await _doubtCommentRepository.GetByIdAsync(Id);
            try
            {
                if (data == null)
                {
                    return await Result<int>.FailAsync("DoubtComment not Found.");
                }
                else
                {
                  
                    
                    var GetDoubtComment = await _doubtRepository.GetByIdAsync(data.DoubtId);
                    await _doubtCommentRepository.DeleteAsync(data);
                    GetDoubtComment.TotalComment = GetDoubtComment.TotalComment - 1;
                    await _doubtRepository.UpdateAsync(GetDoubtComment);
                    return await Result<int>.SuccessAsync("DoubtComment deleted.");
                }
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync("DoubtComment is failed to Delete." + ex.Message);
            }

        }
        #endregion

        #region isLike
        public async Task<Result<int>> IsLike(DoubtLikeRequest doubtLike)

        {
            var data = _mapper.Map<DoubtLike>(doubtLike);
            try 
            {
                if (doubtLike.isLike==1)
                {
                    await _doubtlikeRepository.AddAsync(data);
                    var GetLike = await _doubtRepository.GetByIdAsync(doubtLike.DoubtId);
                    GetLike.TotalLike = GetLike.TotalLike + 1;
                    await _doubtRepository.UpdateAsync(GetLike);
                    return await Result<int>.SuccessAsync(doubtLike.DoubtId, "Like is added.");
                }
                else
                {
                   
                    var GetLike = await _doubtRepository.GetByIdAsync(doubtLike.DoubtId);
                    GetLike.TotalLike = GetLike.TotalLike - 1;
                    await _doubtRepository.UpdateAsync(GetLike);
                    return await Result<int>.SuccessAsync(doubtLike.DoubtId, "Like is removed.");
                }
                
            }
            catch(Exception ex) 
            {

                return await Result<int>.FailAsync("Doubt Like is Failed." + ex.InnerException.Message);
            }

        }

        public async Task<Result<DoubtResponse>> GetDoubtById(int Id)
        {
            var data = await _doubtRepository.GetByIdAsync(Id);
            try
            {

             
                if (data == null)
                {
                    return await Result<DoubtResponse>.FailAsync("Not found"+ Id);
                }
                else
                {
                    var response= _mapper.Map<DoubtResponse>(data);
                    return await Result<DoubtResponse>.SuccessAsync(response);
                }
            }
            catch (Exception e)
            {
                return await Result<DoubtResponse>.FailAsync("Not found" + e.InnerException.Message);
            }

        }
        #endregion

        #region pdfnotes
         public async Task<Result<List<PdfNotesRequest>>> GetPdfNotes(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    var data = await _pdfNotesRepository.GetAllAsync();

                    var mappedData = _mapper.Map<List<PdfNotesRequest>>(data.ToList());
                    mappedData.Select(x => { x.PdfFile = "Pdf_File/Documents/"+x.PdfFile; return x; }).ToList();

                    return await Result<List<PdfNotesRequest>>.SuccessAsync(mappedData);
                }
                else
                {
                    var data = await _pdfNotesRepository.GetAllAsync(X => X.CourseId == Id);

                    var mappedData = _mapper.Map<List<PdfNotesRequest>>(data.ToList());
                    mappedData.Select(x => { x.PdfFile = "Pdf_File/Documents/" + x.PdfFile; return x; }).ToList();
                    return await Result<List<PdfNotesRequest>>.SuccessAsync(mappedData);
                }
            }

            catch (Exception ex)
            {
                return await Result<List<PdfNotesRequest>>.FailAsync("Pdf failed to load... " + ex.Message);
            }

        }

        #endregion

        #region previousYearPaper
        public async Task<Result<List<PreviousYearPaperRequest>>> GetPapersPdf(int Id)
        {
            try
            {
                if (Id == 0)
                {
                    var data = await _paperRepository.GetAllAsync();

                    var mappedData = _mapper.Map<List<PreviousYearPaperRequest>>(data.ToList());
                    mappedData.Select(x => { x.Paperpdf = "Paper_File/Documents/" + x.Paperpdf; return x; }).ToList();

                    return await Result<List<PreviousYearPaperRequest>>.SuccessAsync(mappedData);
                }
                else
                {
                    var data = await _paperRepository.GetAllAsync(x=>x.CourseId==Id);

                    var mappedData = _mapper.Map<List<PreviousYearPaperRequest>>(data.ToList());
                    mappedData.Select(x => { x.Paperpdf = "Paper_File/Documents/" + x.Paperpdf; return x; }).ToList();

                    return await Result<List<PreviousYearPaperRequest>>.SuccessAsync(mappedData);
                }
            }

            catch (Exception ex)
            {
                return await Result<List<PreviousYearPaperRequest>>.FailAsync("Pdf failed to load... " + ex.Message);
            }

        }

        #endregion

        #region BookPdf
        public async Task<Result<List<BookPdfRequest>>> GetBooks(int Cid, int Sid)
        {
            try
            {
                if (Cid==0 && Sid==0)
                {
                    var data = await _bookRepository.GetAllAsync();

                    var mappedData = _mapper.Map<List<BookPdfRequest>>(data.ToList());
                    mappedData.Select(x => { x.BookPdfFile = "Book_File/Documents/" + x.BookPdfFile; return x; }).ToList();

                    return await Result<List<BookPdfRequest>>.SuccessAsync(mappedData);
                }
                else
                {
                    var data = await _bookRepository.GetAllAsync(x => x.CourseId==Cid && x.SubjectId==Sid);

                    var mappedData = _mapper.Map<List<BookPdfRequest>>(data.ToList());
                    mappedData.Select(x => { x.BookPdfFile = "Book_File/Documents/" + x.BookPdfFile; return x; }).ToList();

                    return await Result<List<BookPdfRequest>>.SuccessAsync(mappedData);
                }
            }
            catch (Exception ex)
            {
                return await Result<List<BookPdfRequest>>.FailAsync("Book Pdf Failed to load..." + ex.Message);
            }
        }
        #endregion
       
        #region Faculty
        public async Task<Result<List<FacultyResponse>>> GetFacultyList()
        {
            try
            {
                var data= await _facultyRepository.GetAllAsync();
                List<FacultyResponse> FacultyList = new List<FacultyResponse>();
                foreach (var item in data)
                {
                    FacultyResponse faculty = new FacultyResponse();
                    faculty.Id = item.Id;
                    faculty.Name = item.Name;
                    faculty.Contact = item.Contact;
                    faculty.Email = item.Email;
                    faculty.Qualification = item.Qualification;
                    faculty.Image =item.Image;
                    FacultyList.Add(faculty);
                }
                return await Result<List<FacultyResponse>>.SuccessAsync(FacultyList);
            }
            catch(Exception ex)
            {
                throw ex;
            } 
        }
        #endregion
       
        #region category
        public async Task<Result<List<CategoryResponse>>> GetAllCategory()
        {

            try
            {
                var data = await _categoryRepository.GetAllAsync(x=>x.IsActive==true);
                var mappedData = _mapper.Map<List<CategoryResponse>>(data.ToList());
                return await Result<List<CategoryResponse>>.SuccessAsync(mappedData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Result<CategoryResponse>> GetCategoryById(int Id)
        {
            var data = await _categoryRepository.GetByIdAsync(Id);
            try
            {
                if(data==null)
                {
                    return await Result<CategoryResponse>.FailAsync("Not found" + Id);
                }
                else
                {

                var mappedData = _mapper.Map<CategoryResponse>(data);
                return await Result<CategoryResponse>.SuccessAsync(mappedData);

                }

            }
            catch(Exception ex)
            {
                return await Result<CategoryResponse>.FailAsync("Not found" + ex.InnerException.Message);
            }
        }
        #endregion


        #region SubCategory
        public async Task<Result<List<SubcategoryResponse>>> GetAllSubCategory(int Id)
        {
            try
            {
                var data = await _subcategoryRepository.GetAllAsync(x=>x.CategoryId==Id && x.IsActive==true);
                var mappedData = _mapper.Map<List<SubcategoryResponse>>(data.ToList());
                return await Result<List<SubcategoryResponse>>.SuccessAsync(mappedData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Result<SubcategoryResponse>> GetSubCategoryById(int Cid, int Sid)
        {
            var data = await _subcategoryRepository.GetAllAsync(x => x.CategoryId == Cid);
            try
            {
                if (data == null)
                {
                    return await Result<SubcategoryResponse>.FailAsync("Not found");
                }
                else
                {
                    var data1 = await _subcategoryRepository.GetByIdAsync(Sid);
                    if(data1==null)
                    {
                        return await Result<SubcategoryResponse>.FailAsync("Not found");
                    }
                   else 
                   {
                        var mappedData = _mapper.Map<SubcategoryResponse>(data1);
                        return await Result<SubcategoryResponse>.SuccessAsync(mappedData);

                    }

                }

            }
            catch (Exception ex)
            {
                return await Result<SubcategoryResponse>.FailAsync("Not found" + ex.InnerException.Message);
            }
        }

        #endregion


        #region HelpDesk Response
        public async Task<Result<List<HelpDesk_Response>>> GetAllProblems()
        {
            try
            {
                Expression<Func<HelpDesk, bool>> Where=null;
                Expression<Func<HelpDesk, object>>[] navigationProperties = new Expression<Func<HelpDesk, object>>[] { x => x.SubCategory,y=>y.Category };
              //  var data = await _helpDeskRepository.GetAllAsync();
                var data= await _helpDeskRepository.GetAllWithChildEntitiesAsync(Where,navigationProperties);
                var mappedData = _mapper.Map<List<HelpDesk_Response>>(data.ToList());

                return await Result<List<HelpDesk_Response>>.SuccessAsync(mappedData);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Result<List<HelpDesk_Response>>> GetProblemsByStdId(int Id)
        {
            try
            {
                Expression<Func<HelpDesk, bool>> Where = (x => x.StudentId == Id);
                Expression<Func<HelpDesk, object>>[] navigationProperties = new Expression<Func<HelpDesk, object>>[] { x => x.SubCategory, y => y.Category };
                var data= await _helpDeskRepository.GetAllWithChildEntitiesAsync(Where,navigationProperties);
                var mappedData = _mapper.Map<List<HelpDesk_Response>>(data.ToList());

                return await Result<List<HelpDesk_Response>>.SuccessAsync(mappedData);
            }
            catch (Exception ex)
            {
                return await Result<List<HelpDesk_Response>>.FailAsync("Help Desk Is failed to load..." + ex.Message);
            }
        }
        #endregion

        #region HelpDesk Request
        public async Task<Result<int>> InsertProblems(HelpDesk_Request helpDesk)
            {
            var data = _mapper.Map<HelpDesk>(helpDesk);
            try
            {
                data.CreatedDate = DateTime.Now;
                await _helpDeskRepository.AddAsync(data);
                return await Result<int>.SuccessAsync(data.Id, "Problem inserted Successfully..");
            }
            catch (Exception ex)
            {
                return await Result<int>.FailAsync("Problem is not Added..." + ex.Message);
            }
        }
        public async Task<Result<int>> Updateproblems(HelpDesk_Request helpDesk)
        {
            try
            {
                var data = await _helpDeskRepository.GetByIdAsync(helpDesk.Id);
                if (data != null)
                {
                    data.UpdatedDate = DateTime.Now;
                    data.UpdatedBy = helpDesk.UpdatedBY;
                    data.ProblemDescription = helpDesk.ProblemDescription;
                    await _helpDeskRepository.UpdateAsync(data);
                    return await Result<int>.SuccessAsync(data.Id, "Problem is updated Succesfully..");
                }
                else
                {
                    return await Result<int>.FailAsync("Problem is not Found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Batch
        public async Task<Result<List<BatchResponse>>> GetBatchById(int Id, int type)
        {
            try
            {
                if (Id == 0)
                {

                   var batchdata = await _batchRepositry.GetAllAsync();
                    if(type==1)
                    {
                        batchdata = batchdata.Where(x => x.IsPaid == true);
                    }
                    else if(type==2)
                    {
                        batchdata = batchdata.Where(x => x.IsPaid == false);
                    }

                    var mappedBatchdata = _mapper.Map<List<BatchResponse>>(batchdata);
                    mappedBatchdata.Select(x => { x.SyllabusFile = "BatchFiles/" + x.SyllabusFile; return x; }).ToList();



                    return await Result<List<BatchResponse>>.SuccessAsync(mappedBatchdata);
                   
                }
                else
                {
                    var data = await _batchRepositry.GetAllAsync(x => x.CourseId == Id);

                        if(type==1)
                    {
                        data = data.Where(x => x.IsPaid == true);
                    }
                        else if (type==2)
                    {
                        data = data.Where(x => x.IsPaid == false);
                    }
                    var mappedBatchdata = _mapper.Map<List<BatchResponse>>(data);
                    mappedBatchdata.Select(x => { x.SyllabusFile = "BatchFiles/" + x.SyllabusFile; return x; }).ToList();

                    return await Result<List<BatchResponse>>.SuccessAsync(mappedBatchdata);
                }

            }
            catch (Exception ex)
            {
                return await Result<List<BatchResponse>>.FailAsync("Batch Failed to load.." + ex.Message);
            }
        }
        #endregion
    }
}
