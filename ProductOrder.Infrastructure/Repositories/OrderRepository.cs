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
            // using (var dbTransaction = _context.Database.BeginTransactionAsync())
            // {
                var order = new Order{TotalPrice = 0, Products = new List<Product>()};
                foreach(var product in entity.Products)
                {
                    var entityProduct = await _context.Set<Product>().AsNoTracking().FirstOrDefaultAsync(p => p.Id == product.Id);
                    _logger.LogInformation(JsonSerializer.Serialize(entityProduct));

                    if(entityProduct is null)
                    {
                        throw new Exception("Product not found");
                    }

                    if(entityProduct.Stock - product.Quantity < 0)
                    {
                        throw new Exception("Not enough stock");
                    }

                    entityProduct.Stock -= product.Quantity;
                    await _context.SaveChangesAsync();

                    order.TotalPrice += entityProduct.Price*product.Quantity;
                    order.Products.Add(entityProduct);
                }

            await _context.Set<Order>().AddAsync(order);
            await _context.SaveChangesAsync();
            // }

            return order;
        }

    }
    
}