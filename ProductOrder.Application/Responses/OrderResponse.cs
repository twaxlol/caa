namespace ProductOrder.Application.Responses
{
    public class OrderResponse
    {
        public Guid Id { get; set; }
        public List<ProductResponse> Products { get; set; }
        public decimal TotalPrice { get; set; }
    }
}