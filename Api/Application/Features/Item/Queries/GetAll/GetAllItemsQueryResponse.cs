using Api.Application.Features.Item.Shared;

namespace Api.Application.Features.Item.Queries.GetAll;

public class GetAllItemsQueryResponse
{
    public List<ItemDto> Items { get; set; }
    public int Count { get; set; }
}