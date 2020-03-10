using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MedPark.Common
{
    public class MedParkRepository<TEntity> : IMedParkRepository<TEntity> where TEntity : class, IIdentifiable
    {
        private DbContext _context;

        public MedParkRepository(DbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> BrowseAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var record = await GetAsync(id);
            _context.Set<TEntity>().Remove(record);
            _context.SaveChanges();
        }

        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync() != null;
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
            => await _context.Set<TEntity>().Where(predicate).ToListAsync();

        public async Task<TEntity> GetAsync(Guid id)
         => await GetAsync(e => e.Id == id);

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
         => await _context.Set<TEntity>().Where(predicate).SingleOrDefaultAsync();

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task DeleteAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var records = await FindAsync(predicate);
            _context.Set<TEntity>().RemoveRange(records);
            _context.SaveChanges();
        }
    }
}
