using MediatR;
using ProductOrder.Application.Responses;

namespace ProductOrder.Application.Commands
{
    public class CreateCategoryCommand : IRequest<CategoryResponse>
    {
        public string Name { get; set; }
    }
}