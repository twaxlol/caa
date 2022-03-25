using MediatR;
using ProductOrder.Application.Responses;

namespace ProductOrder.Application.Queries
{
    public class GetProductByIdQuery : IRequest<ProductResponse>
    {
        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}