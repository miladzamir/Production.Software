using MediatR;
using Microsoft.AspNetCore.Mvc;
using Production.Software.Application.Commands;
using Production.Software.Application.Queries;
using Production.Software.Application.Responses;
using Production.Software.Core.Entities;

namespace Production.Software.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;
    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<List<Product>> Get()
    {
        return await _mediator.Send(new GetAllProductQuery());
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ProductResponse>> Create([FromBody] CreateProductCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}