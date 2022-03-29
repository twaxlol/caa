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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category{ Id = Guid.NewGuid(), Name="TestCategory1"},
                new Category{ Id = Guid.NewGuid(), Name="TestCategory2"}
            );


            modelBuilder.Entity<Product>().HasData(
                new Product{ Id = Guid.NewGuid(), Name = "test1", Description="test1Desc", Price=22},
                new Product{ Id = Guid.NewGuid(), Name = "test2", Description = "test2Desc", Price = 25}
            );
        }
    }
    
}