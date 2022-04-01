using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductOrder.Core.Models
{
    public class Product 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Order> Orders { get; set; }
    }    
}