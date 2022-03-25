using AutoMapper;
using MediatR;
using ProductOrder.Application.Queries;
using ProductOrder.Application.Responses;
using ProductOrder.Core.Repositories;

namespace ProductOrder.Application.Handlers
{
    public class GetProductsListHandler : IRequestHandler<GetProductsListQuery, List<ProductResponse>>
    {
        private IProductRepository _repo;
        private IMapper _mapper;
        public GetProductsListHandler(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<ProductResponse>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            var products = await _repo.GetAllAsync();
            var productResponses = _mapper.Map<List<ProductResponse>>(products);
            return productResponses;
        }
    }
}