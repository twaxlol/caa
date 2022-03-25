using AutoMapper;
using MediatR;
using ProductOrder.Application.Queries;
using ProductOrder.Application.Responses;
using ProductOrder.Core.Repositories;

namespace ProductOrder.Application.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductResponse>
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public GetProductByIdHandler(IProductRepository productRepository, IMapper mapper)
        {
            _repo = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repo.GetByIdAsync(request.Id);
            var responseProduct = _mapper.Map<ProductResponse>(entity);
            return responseProduct;
        }
    }
}