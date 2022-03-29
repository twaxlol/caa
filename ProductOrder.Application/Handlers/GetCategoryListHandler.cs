using MediatR;
using ProductOrder.Application.Responses;
using ProductOrder.Application.Queries;
using ProductOrder.Core.Repositories;
using AutoMapper;

namespace ProductOrder.Application.Handlers
{
    public class GetCategoryListHandler : IRequestHandler<GetCategoryListQuery, List<CategoryResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repo;
        public GetCategoryListHandler(IMapper mapper, ICategoryRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public async Task<List<CategoryResponse>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categories = await _repo.GetAllAsync();
            var responseCategories = _mapper.Map<List<CategoryResponse>>(categories);
            return responseCategories;
        }
    }
}