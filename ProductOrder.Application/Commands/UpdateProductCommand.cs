using MediatR;
using ProductOrder.Application.Responses;

namespace ProductOrder.Application.Commands
{
    public class UpdateProductCommand : IRequest<ProductResponse>
    {
        public Guid Id { get; set; }
        public int Stock { get; set; }
    }    
}