using Api.Application.Features.Item.Shared;
using MediatR;

namespace Api.Application.Features.Item.Queries.GetByName;

public class GetItemByNameQuery : IRequest<ItemDto>
{
    public string ItemName { get; set; }
}