using Microsoft.EntityFrameworkCore;
using ProductOrder.Core.Repositories;
using ProductOrder.Infrastructure.Data;

namespace ProductOrder.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ProductOrderDbContext _context;
        public BaseRepository(ProductOrderDbContext context)
        {
            _context = context;
        }
        public async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var entityToDelete = await _context.Set<T>().FindAsync(id);
            if(entityToDelete is null)
            {
                throw new Exception();
            }
            _context.Set<T>().Remove(entityToDelete);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if(entity is null)
            {
                throw new Exception();
            }
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}