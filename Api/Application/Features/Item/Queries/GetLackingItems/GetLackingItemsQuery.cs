using Api.Application.Features.Item.Shared;
using MediatR;

namespace Api.Application.Features.Item.Queries.GetLackingItems;

public class GetLackingItemsQuery : IRequest<List<LackingItemDto>>
{
    
}