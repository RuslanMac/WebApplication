using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DbRepository<TEntity> : IDbRepository<TEntity> 
        where TEntity: class
    {
        private readonly AppDbContext _context;

        public DbRepository(AppDbContext context)
        {
            _context = context;
        }
 
        public IQueryable<TEntity> Get()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> selector)
        {
           
            return _context.Set<TEntity>().Where(selector).AsQueryable();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public async Task AddAsync(TEntity newEntity)
        {
            await _context.Set<TEntity>().AddAsync(newEntity);
            await SaveChangesAsync();

        }

        public async Task AddRange(IEnumerable<TEntity> newEntities)
        {
            await _context.Set<TEntity>().AddRangeAsync(newEntities);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity activeEntity)
        { 
            _context.Set<TEntity>().Remove(activeEntity);
            await SaveChangesAsync();
        }

        public async Task Remove(TEntity entity)
        {
            await Task.Run(() => _context.Set<TEntity>().Remove(entity));
            await SaveChangesAsync();
        }

        public async Task RemoveRange(IEnumerable<TEntity> entities)
        {
            await Task.Run(() => _context.Set<TEntity>().RemoveRange(entities));
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => _context.Set<TEntity>().Update(entity));
            await SaveChangesAsync();
        }

        public async Task UpdateRange(IEnumerable<TEntity> entities)
        {
            await Task.Run(() => _context.Set<TEntity>().UpdateRange(entities));
            await SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            try
            {
              return await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
    
                if (e != null)
                {
                    throw new DbUpdateException();//return the error string
                }
                throw;
            }
  
        }
    }
}
