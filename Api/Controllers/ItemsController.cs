using System.Net;
using Api.Application.Attributes;
using Api.Application.Features.Authentication.Commands.Login;
using Api.Application.Features.Item.Commands.Create;
using Api.Application.Features.Item.Commands.Delete;
using Api.Application.Features.Item.Commands.Modify;
using Api.Application.Features.Item.Commands.Order;
using Api.Application.Features.Item.Commands.Update;
using Api.Application.Features.Item.Queries.GetAll;
using Api.Application.Features.Item.Queries.GetByName;
using Api.Application.Features.Item.Queries.GetLackingItems;
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
public class ItemsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <remarks>
    /// Allowed roles: InventoryManager
    /// </remarks>
    [HttpPost]
    [AuthorizeEnums(Roles.InventoryManager)]
    public async Task<ActionResult<Unit>> Create(CreateItemCommand request)
    {
        return Ok(await _mediator.Send(request));
    }
    
    /// <remarks>
    /// <para>Allowed roles: InventoryManager</para>
    /// <para>Updates whole entity</para>
    /// </remarks>
    [HttpPut]
    [AuthorizeEnums(Roles.InventoryManager)]
    public async Task<ActionResult<Unit>> Update(UpdateItemCommand request)
    {
        return Ok(await _mediator.Send(request));
    }
    
    /// <remarks>
    /// <para>Allowed roles: InventoryManager, Technician, Housemaid</para>
    /// <para>Only manipulates with the amount of items</para>
    /// <para>If "Amount" is positive, then this number will be added to the existing item.</para>
    /// <para>If "Amount" is negative, then this number will be subtracted from the item.</para>
    /// </remarks>
    [HttpPut("modify")]
    [AuthorizeEnums(Roles.InventoryManager, Roles.Technician, Roles.Housemaid)]
    public async Task<ActionResult<ModifyItemCommandResponse>> Modify(ModifyItemCommand request)
    {
        return Ok(await _mediator.Send(request));
    }
    
    /// <remarks>
    /// Allowed roles: InventoryManager
    /// </remarks>
    [HttpDelete]
    [AuthorizeEnums(Roles.Administrator)]
    public async Task<ActionResult<Unit>> Delete(Guid itemId)
    {
        return Ok(await _mediator.Send(new DeleteItemCommand { ItemId = itemId }));
    }
    
    /// <remarks>
    /// <para>Allowed roles: any (except non-authorized)</para>
    /// <para>When "name" in query provided, than returns 1 item by name</para>
    /// <para>When not, returns all items</para>
    /// </remarks>
    [HttpGet]
    public async Task<ActionResult<List<ItemDto>>> Get([FromQuery] string? name)
    {
        if(name is null)
            return Ok(await _mediator.Send(new GetAllItemsQuery()));
        
        return Ok(await _mediator.Send(new GetItemByNameQuery { ItemName = name }));
    }
    
    /// <remarks>
    /// Allowed roles: InventoryManager
    /// </remarks>
    [HttpGet("lackingItems")]
    public async Task<ActionResult> GetLackingItems()
    {
        return Ok(await _mediator.Send(new GetLackingItemsQuery()));
    }
    
    /// <remarks>
    /// Allowed roles: InventoryManager
    /// </remarks>
    [HttpPut("order")]
    public async Task<ActionResult> OrderItems(OrderItemsCommand request)
    {
        return Ok(await _mediator.Send(request));
    }
}