using MediatR;
using ProductOrder.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using ProductOrder.Application.Queries;
using ProductOrder.Application.Commands;

[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;
    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("/")]
    public async Task<ActionResult<List<CategoryResponse>>> Get()
    {
        var res = await _mediator.Send(new GetCategoryListQuery());
        return Ok(res);
    }

    [HttpPost]
    [Route("/")]
    public async Task<ActionResult<CategoryResponse>> Post([FromBody] CreateCategoryCommand command)
    {
        var res = await _mediator.Send(command);
        return Ok(res);
    }
}