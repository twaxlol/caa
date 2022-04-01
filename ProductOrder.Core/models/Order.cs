namespace ProductOrder.Core.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public ICollection<Product> Products { get; set; }
        public decimal TotalPrice { get; set; }
    }
}