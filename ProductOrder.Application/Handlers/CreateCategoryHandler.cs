using AutoMapper;
using MediatR;
using ProductOrder.Application.Commands;
using ProductOrder.Application.Responses;
using ProductOrder.Core.Models;
using ProductOrder.Core.Repositories;

namespace ProductOrder.Application.Handlers
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repo;
        public CreateCategoryHandler(IMapper mapper, ICategoryRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public async Task<CategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entityCategory = _mapper.Map<Category>(request);
            await _repo.CreateAsync(entityCategory);
            var responseCategory = _mapper.Map<CategoryResponse>(entityCategory);
            return responseCategory;
        }
    }
}