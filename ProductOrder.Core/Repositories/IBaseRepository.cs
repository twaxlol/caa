namespace ProductOrder.Core.Repositories
{
    public interface IBaseRepository<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(Guid id);
        public Task<T> CreateAsync(T entity);
        public Task<T> UpdateAsync(T entity, Guid Id);
        public Task DeleteByIdAsync(Guid id);
    }
    
}