using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Data;

namespace CleanArchitecture.Infrastructure.Repositories
{
    /// <summary>
    /// Generic methods for objects persistence
    /// </summary>
    /// <typeparam name="T">entity</typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    { 
        protected readonly CleanArchitectureDbContext _context;

        /// <summary>
        /// Initialize dbContext
        /// </summary>
        /// <param name="context"></param>
        public BaseRepository(CleanArchitectureDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Save entity
        /// </summary>
        /// <param name="entity"></param>
        public void Create(T entity)
        {
            _context.Add(entity);
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            _context.Update(entity);
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        /// <summary>
        /// Save changes in database
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
