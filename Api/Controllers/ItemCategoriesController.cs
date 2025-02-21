using Api.Application.Features.ItemCategory.Common;
using Api.Application.Features.ItemCategory.Query.GetAll;
using DocumentFormat.OpenXml.Wordprocessing;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Authorize]
[Route("api/v1/itemCategories")]
public class ItemCategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemCategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    /// <remarks>
    /// <para>Allowed roles: any (except non-authorized)</para>
    /// </remarks>
    [HttpGet]
    public async Task<ActionResult<List<ItemCategoryDto>>> Get([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20)
    {
        return Ok(await _mediator.Send(new GetAllItemCategoriesQuery { PageNumber = pageNumber, PageSize = pageSize }));
    }
}