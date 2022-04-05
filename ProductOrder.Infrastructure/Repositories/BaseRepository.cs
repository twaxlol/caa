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
        public virtual async Task<T> CreateAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception($"Error creating the {entity.GetType().Name}");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var entityToDelete = await _context.Set<T>().FindAsync(id);
            if(entityToDelete is null)
            {
                throw new Exception("Not found");
            }
            _context.Set<T>().Remove(entityToDelete);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if(entity is null)
            {
                throw new Exception("Not found");
            }
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity, Guid Id)
        {
            var foundEntity = await _context.Set<T>().FindAsync(Id);
            if(foundEntity is null) throw new Exception("Not found");
            foundEntity = entity;
            await _context.SaveChangesAsync();
            return foundEntity;
        }
    }
}