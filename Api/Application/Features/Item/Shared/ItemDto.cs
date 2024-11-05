namespace Api.Application.Features.Item.Shared;

public class ItemDto
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public int MinimumStockQuantity { get; set; }
}