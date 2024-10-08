using ELearning.Interface;
using ELearning.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace ELearning.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ELearningContext _context;
        protected DbSet<T> dbSet;

        public GenericRepository(ELearningContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }

        //Generic method for add
        public virtual async Task<T> AddAsync(T entity)
        {
            var i = await _context.AddAsync(entity);
            _context.SaveChanges();
            return entity;
        }

        public async Task<T> BulkAddAsync(List<T> entity)
        {
            await _context.AddRangeAsync(entity);
            _context.SaveChanges();
            return entity.ToList().FirstOrDefault();
        }
        public async Task BulkDeleteAsync(List<T> entity)
        {
            entity.ForEach(x =>
            {
                _context.Entry(x).State = EntityState.Deleted;
            });
            _context.SaveChanges();
        }
        public async Task BulkUpdateAsync(List<T> entity)
        {
            _context.UpdateRange(entity);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

       



        public async Task<IReadOnlyList<T>> GetPagedReponseAsync(int pageNumber, int pageSize, Expression<Func<T, bool>> Where = null)
        {
            var query = dbSet.AsNoTracking().AsQueryable();
            if (Where != null)
                query = query.Where(Where);

            var model = await query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();

            return model;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        #region Dispose


        #region GetAll Methods

        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> Where = null)
        {
            try
            {
                IQueryable<T> entities = _context.Set<T>();

                if (Where != null)
                    entities = entities.Where(Where);

                return await entities.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task<IEnumerable<T>> GetAllWithChildEntitiesAsync(Expression<Func<T, bool>> Where, params Expression<Func<T, object>>[] navigationProperties)
        {
            try
            {
                IQueryable<T> entities = _context.Set<T>();

                if (navigationProperties != null)
                    navigationProperties.ToList().ForEach(x => entities.Include(x).Load());

                if (Where != null)
                    entities = entities.Where(Where);

                return await entities.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }



        #endregion

    }

}