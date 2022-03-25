using MediatR;
using ProductOrder.Application.Responses;

namespace ProductOrder.Application.Queries
{
    public class GetProductsListQuery : IRequest<List<ProductResponse>>
    {
        
    }
}