using LeadTracker.Core.Entities;
using LeadTracker.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LeadTracker.Infrastructure
{
    public abstract class Repository<T> : IRepository<T> where T : Identity
    {
        public readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return await Task.FromResult(_context.Set<T>().AsNoTracking());
        }

        public async Task<IQueryable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await Task.FromResult(_context.Set<T>().Where(expression).AsNoTracking());
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task UpdateAsync(T entity)
        {
            //_context.Set<T>().Update(entity);
            //await _context.SaveChangesAsync();

            var existingEntity = await _context.Set<T>().FindAsync(entity.Id);
            if (existingEntity != null)
            {
                
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            entity.IsActive = false;
            entity.IsDeleted = true;
            await UpdateAsync(entity);
            await _context.SaveChangesAsync();
        }

        //public Task<T> GetByIdAsync(long id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task DeleteAsync(long id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
