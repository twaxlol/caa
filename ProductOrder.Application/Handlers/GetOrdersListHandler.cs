using AutoMapper;
using MediatR;
using ProductOrder.Application.Queries;
using ProductOrder.Application.Responses;
using ProductOrder.Core.Models;
using ProductOrder.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductOrder.Application.Handlers
{
    public class GetOrdersListHandler : IRequestHandler<GetOrdersListQuery, List<OrderResponse>>
    {
        private readonly IOrderRepository _repo;
        private readonly IMapper _mapper;

        public GetOrdersListHandler(IOrderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<OrderResponse>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var res = await _repo.GetAllAsync();
            var orderResponse = new List<OrderResponse>();
            foreach (var item in res)
            {
                orderResponse.Add(new OrderResponse
                {
                    Id = item.Id,
                    Products = item.Products.Select(p => _mapper.Map<ProductResponse>(p)).ToList(),
                    TotalPrice = item.TotalPrice
                });
            }
            return orderResponse;
        }
    }
}
