using AutoMapper;
using MediatR;
using ProductOrder.Application.Commands;
using ProductOrder.Application.Responses;
using ProductOrder.Core.Models;
using ProductOrder.Core.Repositories;

namespace ProductOrder.Application.Handlers
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, OrderResponse>
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IMapper _mapper;
        public CreateOrderHandler(IOrderRepository orderRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }
        public async Task<OrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
           var entityOrder = new Order
           {
               Products = request.Products.Select(p => new Product{Id = p.Id, Quantity = p.Quantity}).ToList()
           };
           var order = await _orderRepo.CreateAsync(entityOrder);
           var orderResponse = new OrderResponse
           {
               Id = order.Id,
               TotalPrice = order.TotalPrice,
               Products = order.Products.Select(p => _mapper.Map<ProductResponse>(p)).ToList()
           };
           return orderResponse;

        }
    }
}