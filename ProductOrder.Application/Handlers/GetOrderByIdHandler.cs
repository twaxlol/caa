using AutoMapper;
using MediatR;
using ProductOrder.Application.Queries;
using ProductOrder.Application.Responses;
using ProductOrder.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductOrder.Application.Handlers
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, OrderResponse>
    {
        private readonly IOrderRepository _repo;
        private readonly IMapper _mapper;

        public GetOrderByIdHandler(IOrderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<OrderResponse> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var entityOrder = await _repo.GetByIdAsync(request.Id);
            var orderResponse = new OrderResponse {
                Id = entityOrder.Id,
                Products = entityOrder.Products.Select(p => _mapper.Map<ProductResponse>(p)).ToList(),
                TotalPrice = entityOrder.TotalPrice 
            };
            return orderResponse;
        }
    }
}
