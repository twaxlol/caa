using Microsoft.EntityFrameworkCore;
using ProductOrder.Core.Models;
using ProductOrder.Core.Repositories;
using ProductOrder.Infrastructure.Data;

namespace ProductOrder.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {

        public ProductRepository(ProductOrderDbContext context) : base(context)
        {
        }
        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await _context.Set<Product>()
                .Include(c => c.Category)
                .ToListAsync();
            return products;
        }

        public override async Task<Product> CreateAsync(Product entity)
        {
            var res = await base.CreateAsync(entity);
            res.Category = _context.Set<Category>().FirstOrDefault(c => c.Id == entity.CategoryId);
            return res;
        }

    }
}