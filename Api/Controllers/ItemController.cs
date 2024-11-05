using Api.Application.Features.Authentication.Commands.Login;
using Api.Application.Features.Item.Queries.GetAll;
using Api.Application.Features.Item.Queries.GetByName;
using Api.Application.Features.Item.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/items")]
[Authorize]
public class ItemController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<ItemDto>>> Get([FromQuery] string? name)
    {
        if(name is null)
            return Ok(await _mediator.Send(new GetAllItemsQuery()));
        
        return Ok(await _mediator.Send(new GetItemByNameQuery { ItemName = name }));
    }
}