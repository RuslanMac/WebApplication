using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public interface IDbRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="selector">selector</param>
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> selector);

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="selector">selector</param>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Get
        /// </summary>
        IQueryable<TEntity> Get();

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="newEntity">newEntity</param>
        Task AddAsync(TEntity newEntity);

        /// <summary>
        /// AddRange
        /// </summary>
        /// <param name="newEntities">newEntities</param>
        Task AddRange(IEnumerable<TEntity> newEntities);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="activeEntity">activeEntity</param>
        /// <returns></returns>
        Task DeleteAsync(TEntity activeEntity);

        /// <summary>
        /// Remove
        /// </summary>
        /// <param name="entity">entity</param>
        Task Remove(TEntity entity);

        /// <summary>
        /// RemoveRange
        /// </summary>
        /// <param name="entities">entities</param>
        Task RemoveRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity">entity</param>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// UpdateRange
        /// </summary>
        /// <param name="entities">entities</param>
        Task UpdateRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// SaveChangesAsync
        /// </summary>
        Task<int> SaveChangesAsync();
    }
}
