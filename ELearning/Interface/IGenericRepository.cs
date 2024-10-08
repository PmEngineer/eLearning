using System.Linq.Expressions;

namespace ELearning.Interface
{
   
        public interface IGenericRepository<T> : IDisposable where T : class
        {
            Task<T> GetByIdAsync(int id);
            #region GetAll Methods

            Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> Where = null);


            #endregion
            Task<IReadOnlyList<T>> GetPagedReponseAsync(int pageNumber, int pageSize, Expression<Func<T, bool>> Where = null);
            Task<T> AddAsync(T entity);
            Task UpdateAsync(T entity);
            Task DeleteAsync(T entity);
            Task<T> BulkAddAsync(List<T> entity);
            Task BulkUpdateAsync(List<T> entity);
            Task BulkDeleteAsync(List<T> entity);
            #region Dispose Methods

            void Dispose();

            #endregion
        }
    
}
