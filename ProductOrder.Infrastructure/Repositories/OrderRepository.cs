using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductOrder.Core.Models;
using ProductOrder.Core.Repositories;
using ProductOrder.Infrastructure.Data;

namespace ProductOrder.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly ILogger<OrderRepository> _logger;
        public OrderRepository(ProductOrderDbContext context, ILogger<OrderRepository> logger) : base(context)
        {
            _logger = logger;
        }

        public override async Task<Order> CreateAsync(Order entity)
        {
            var order = new Order { Products = new List<Product>() };
            await _context.AddAsync(order);
            foreach (var product in entity.Products)
            {
                var dbProduct = await _context.Set<Product>().Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == product.Id);

                if (dbProduct is null) throw new Exception($"Product was not found with the id: {product.Id}");

                var updatedProductStock = dbProduct.Stock - product.Quantity;
                if (updatedProductStock < 1) throw new Exception($"Not enough stock of the product with id: {dbProduct.Id}");
                dbProduct.Stock = updatedProductStock;

                order.TotalPrice += dbProduct.Price * product.Quantity;

                order.Products.Add(dbProduct);
                await _context.SaveChangesAsync();
            }
            return order;
        }

        public override async Task<IEnumerable<Order>> GetAllAsync()
        {
            var res = await _context.Set<Order>()
                .Include(o => o.Products)
                .ThenInclude(p => p.Category)
                .ToListAsync();

            return res;
        }

        public override async Task<Order> GetByIdAsync(Guid id)
        {
            var res = await _context.Set<Order>()
                .Include(o => o.Products)
                .ThenInclude(p => p.Category)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (res is null) throw new Exception("Not found");
            return res;
        }



    }
    
}