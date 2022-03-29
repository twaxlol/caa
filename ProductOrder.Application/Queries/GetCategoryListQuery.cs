using MediatR;
using ProductOrder.Application.Responses;

namespace ProductOrder.Application.Queries
{
    public class GetCategoryListQuery : IRequest<List<CategoryResponse>>
    {

    }    
}