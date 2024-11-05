using Api.Application.Features.Authentication.Commands.Login;
using Api.Application.Features.Item.Queries.GetAll;
using Api.Application.Features.Item.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/items")]
public class ItemController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("getAll")]
    public async Task<ActionResult<List<ItemDto>>> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllItemsQuery()));
    }
}