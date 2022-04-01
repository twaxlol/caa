using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductOrder.Application.Responses;
using ProductOrder.Application.Queries;
using ProductOrder.Application.Commands;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductResponse>>> Get()
    {
        var res = await _mediator.Send(new GetProductsListQuery());
        return Ok(res);
    }

    [HttpGet]
    [Route("/[controller]/{id}")]
    public async Task<ActionResult<ProductResponse>> Get(Guid id)
    {
        var res = await _mediator.Send(new GetProductByIdQuery(id));
        return Ok(res);
    }

    [HttpPost]
    public async Task<ActionResult<ProductResponse>> Post([FromBody] CreateProductCommand command)
    {
        var res = await _mediator.Send(command);
        return Ok(res);
    }

    [HttpPatch]
    public async Task<ActionResult<ProductResponse>> Update([FromBody] UpdateProductCommand command)
    {
        var res = await _mediator.Send(command);
        return Ok(res);
    }
}