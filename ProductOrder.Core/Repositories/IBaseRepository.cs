namespace ProductOrder.Core.Repositories
{
    public interface IBaseRepository<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(Guid id);
        public Task<T> CreateAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteByIdAsync(Guid id);
    }
    
}