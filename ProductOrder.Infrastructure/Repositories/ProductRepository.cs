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
    }
}