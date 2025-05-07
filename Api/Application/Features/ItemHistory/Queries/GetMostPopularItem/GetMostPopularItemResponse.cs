using Api.Application.Features.Item.Shared;

namespace Api.Application.Features.ItemHistory.Queries.GetMostPopularItem;

public class GetMostPopularItemResponse
{
    public ItemDto Item { get; set; }
    public int Interactions { get; set; }
}