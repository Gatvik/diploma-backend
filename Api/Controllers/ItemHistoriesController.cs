using Api.Application.Features.ItemHistory.Common;
using Api.Application.Features.ItemHistory.Queries.GetAllWithPagination;
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
    public async Task<ActionResult<List<ItemHistoryDto>>> GetAll(int pageNumber, int pageSize)
    {
        return Ok(await _mediator.Send(new GetAllItemHistoriesWithPaginationQuery { PageNumber = pageNumber, PageSize = pageSize}));
    }
}