using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductOrder.Application.Commands;
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
        public async Task<OrderResponse> Get()
        {
           // _mediator.Send(new)
           throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<OrderResponse>> Post([FromBody] CreateOrderCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}