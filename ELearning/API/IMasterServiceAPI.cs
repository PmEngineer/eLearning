using ELearning.Profiles;
using ELearning.Request;
using ELearning.Response;
using ELearning_Core.Model;
using ELearning_Core.Model.Master;
using ELearning_Core.Shared;

namespace ELearning.API
{
    public interface IMasterServiceAPI
    {
        public Task<Result<List<Subject>>> GetSubjectsList();
        public Task<Result<List<CourseResponse>>> GetCourseList();
        public Task<Result<List<Lessons>>> GetLessonist(int Subid);

        #region Doubt
        public Task<Result<List<DoubtResponse>>> GetDoubtsList(int subjectId);
        public Task<Result<List<DoubtResponse>>> GetDoubts(string userName);
        public Task<Result<DoubtResponse>> GetDoubtById(int Id);
        public Task<Result<int>> InsertDoubt(DoubtRequest doubt);
        public Task<Result<int>> UpdateDoubt(DoubtRequest doubt);
        public Task<Result<int>> DeleteDoubt(int Id);
      
        #endregion

        #region DoubtComment
        public Task<Result<List<DoubtCommentResponse>>> GetAllDoubtComment(int Id);
        public Task<Result<int>> IsLike(DoubtLikeRequest doubtLike);
        public Task<Result<int>> InsertDoubtComment(DoubtCommentResponse doubtComment);
        public Task<Result<int>> UpdateDoubtComment(DoubtCommentRequest request);

        //public Task<Result<List<DoubtCommentResponse>>> GetComment(int Id);
        
        public Task<Result<int>> DeleteDoubtComment(int Id);
        #endregion

        #region pdfnotes
        public Task<Result<List<PdfNotesRequest>>> GetPdfNotes(int Id);
        #endregion

        #region previousYearNote

        public Task<Result<List<PreviousYearPaperRequest>>> GetPapersPdf(int Id);
        #endregion

        #region BookPdfFile
        public Task<Result<List<BookPdfRequest>>> GetBooks(int Cid, int Sid);
        #endregion

        #region Faculty
        public Task<Result<List<FacultyResponse>>> GetFacultyList();
        #endregion

        #region Batch

        #endregion

        #region category
        public Task<Result<List<CategoryResponse>>> GetAllCategory();
        public Task<Result<CategoryResponse>> GetCategoryById(int Id);
        #endregion

        #region SubCategory
        public Task<Result<List<SubcategoryResponse>>> GetAllSubCategory(int Id);
        public Task<Result<SubcategoryResponse>> GetSubCategoryById(int Cid,int Sid );
        #endregion

        #region HelpDesk
        public Task<Result<List<HelpDesk_Response>>> GetAllProblems();
        public Task<Result<List<HelpDesk_Response>>> GetProblemsByStdId(int Id);
        public Task<Result<int>> InsertProblems(HelpDesk_Request helpDesk);
        public Task<Result<int>> Updateproblems(HelpDesk_Request helpDesk);
        #endregion

        #region Batch
        public Task<Result<List<BatchResponse>>> GetBatchById(int Id);
        #endregion
    }
}


