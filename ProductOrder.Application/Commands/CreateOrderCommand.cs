using MediatR;
using ProductOrder.Application.Responses;

namespace ProductOrder.Application.Commands
{
    public class CreateOrderCommand : IRequest<OrderResponse>
    {
        public IEnumerable<ProductOrderModel> Products { get; set; }
    }

    public sealed class ProductOrderModel
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
}