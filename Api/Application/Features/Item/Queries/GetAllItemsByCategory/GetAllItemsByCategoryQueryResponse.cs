using Api.Application.Features.Item.Shared;

namespace Api.Application.Features.Item.Queries.GetAllByCategory;

public class GetAllItemsByCategoryQueryResponse
{
    public List<ItemDto> Items { get; set; }
    public int Count { get; set; }
}