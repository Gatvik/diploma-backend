using Api.Application.Attributes;
using Api.Application.Features.Authentication.Commands.Login;
using Api.Application.Features.Item.Commands.Create;
using Api.Application.Features.Item.Commands.Delete;
using Api.Application.Features.Item.Commands.Modify;
using Api.Application.Features.Item.Commands.Update;
using Api.Application.Features.Item.Queries.GetAll;
using Api.Application.Features.Item.Queries.GetByName;
using Api.Application.Features.Item.Shared;
using Api.Data.Models;
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

    [HttpPost]
    [AuthorizeEnums(Roles.InventoryManager)]
    public async Task<ActionResult<Unit>> Create(CreateItemCommand request)
    {
        return Ok(await _mediator.Send(request));
    }
    
    [HttpPut]
    [AuthorizeEnums(Roles.InventoryManager)]
    public async Task<ActionResult<Unit>> Update(UpdateItemCommand request)
    {
        return Ok(await _mediator.Send(request));
    }
    
    [HttpPut("modify")]
    [AuthorizeEnums(Roles.InventoryManager, Roles.Technician, Roles.Housemaid)]
    public async Task<ActionResult<ModifyItemCommandResponse>> Modify(ModifyItemCommand request)
    {
        return Ok(await _mediator.Send(request));
    }
    
    [HttpDelete]
    [AuthorizeEnums(Roles.Administrator, Roles.InventoryManager)]
    public async Task<ActionResult<Unit>> Delete(Guid itemId)
    {
        return Ok(await _mediator.Send(new DeleteItemCommand { ItemId = itemId }));
    }

    [HttpGet]
    public async Task<ActionResult<List<ItemDto>>> Get([FromQuery] string? name)
    {
        if(name is null)
            return Ok(await _mediator.Send(new GetAllItemsQuery()));
        
        return Ok(await _mediator.Send(new GetItemByNameQuery { ItemName = name }));
    }
}