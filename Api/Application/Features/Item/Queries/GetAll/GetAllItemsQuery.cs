using Api.Application.Features.Item.Shared;
using MediatR;

namespace Api.Application.Features.Item.Queries.GetAll;

public class GetAllItemsQuery : IRequest<List<ItemDto>>
{
    
}