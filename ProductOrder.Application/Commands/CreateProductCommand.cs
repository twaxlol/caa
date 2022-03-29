using MediatR;
using ProductOrder.Application.Responses;

namespace ProductOrder.Application.Commands
{
    public class CreateProductCommand : IRequest<ProductResponse>
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}