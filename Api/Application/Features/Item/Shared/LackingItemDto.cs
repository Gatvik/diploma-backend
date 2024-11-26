namespace Api.Application.Features.Item.Shared;

public class LackingItemDto
{
    public string Name { get; set; }
    public int RecommendedQuantityToOrder { get; set; }
    public int Quantity { get; set; }
    public int MinimumStockQuantity { get; set; }
}