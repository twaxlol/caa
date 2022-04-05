using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductOrder.Application.Commands;
using ProductOrder.Application.Queries;
using ProductOrder.Application.Responses;

namespace ProductOrder.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderResponse>>> Get()
        {
            var res = await _mediator.Send(new GetOrdersListQuery());
            return Ok(res);
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<OrderResponse>> Get(Guid id)
        {
            var res = await _mediator.Send(new GetOrderByIdQuery(id));
            return Ok(res);
        }

        [HttpPost]
        public async Task<ActionResult<OrderResponse>> Post([FromBody] CreateOrderCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}