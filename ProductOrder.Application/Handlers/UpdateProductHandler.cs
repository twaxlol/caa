using AutoMapper;
using MediatR;
using ProductOrder.Application.Commands;
using ProductOrder.Application.Responses;
using ProductOrder.Core.Models;
using ProductOrder.Core.Repositories;

namespace ProductOrder.Application.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductResponse>
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public UpdateProductHandler(IProductRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Product{ Id = request.Id, Stock = request.Stock };
            var dbEntity = await _repo.UpdateAsync(entity, entity.Id);
            var productResponse = _mapper.Map<ProductResponse>(dbEntity);
            return productResponse;
        }
    }
}