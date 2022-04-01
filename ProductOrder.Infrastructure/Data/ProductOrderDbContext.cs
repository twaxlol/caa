using Microsoft.EntityFrameworkCore;
using ProductOrder.Core.Models;

namespace ProductOrder.Infrastructure.Data
{
    public class ProductOrderDbContext : DbContext
    {
        public ProductOrderDbContext(DbContextOptions options) : base(options)
        {
        }

        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Product>().Ignore(p => p.Quantity);
        }
    }
    
}