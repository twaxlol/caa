using AutoMapper;
using MediatR;
using ProductOrder.Application.Commands;
using ProductOrder.Application.Responses;
using ProductOrder.Core.Models;
using ProductOrder.Core.Repositories;

namespace ProductOrder.Application.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResponse>
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public CreateProductHandler(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = _mapper.Map<Product>(request);
            await _repo.CreateAsync(productEntity);
            var productResponse = _mapper.Map<ProductResponse>(productEntity);
            return productResponse;
        }
    }
}