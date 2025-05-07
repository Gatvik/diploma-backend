using Api.Application.Attributes;
using Api.Application.Exceptions;
using Api.Application.Features.ItemHistory.Common;
using Api.Application.Features.ItemHistory.Queries.GetAllByMonth;
using Api.Application.Features.ItemHistory.Queries.GetAllWithPagination;
using Api.Application.Features.ItemHistory.Queries.GetMostPopularItem;
using Api.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/itemHistories")]
[Authorize]
public class ItemHistoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemHistoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <remarks>
    /// <para>Allowed roles: any (except non-authorized)</para>
    /// </remarks>
    [HttpGet]
    public async Task<ActionResult<List<ItemHistoryDto>>> GetAll(int? pageNumber, int? pageSize, int? month)
    {
        if (pageNumber is not null && pageSize is not null)
            return Ok(await _mediator.Send(
                new GetAllItemHistoriesWithPaginationQuery { PageNumber = pageNumber.Value, PageSize = pageSize.Value}));
        if (month is not null)
            return Ok(await _mediator.Send(new GetAllItemHistoriesByMonthQuery { Month = month.Value }));

        throw new BadRequestException("Either pageNumber, pageSize or month must be provided");
    }

    /// <remarks>
    /// <para>Allowed roles: InventoryManager (except non-authorized)</para>
    /// </remarks>
    [HttpGet("mostPopularItem")]
    [AuthorizeEnums(Roles.InventoryManager)]
    public async Task<ActionResult<List<ItemHistoryDto>>> GetMostPopularItem()
    {
        return Ok(await _mediator.Send(new GetMostPopularItemQuery()));
    }
}