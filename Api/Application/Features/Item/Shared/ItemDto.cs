using Api.Application.Features.ItemCategory.Common;

namespace Api.Application.Features.Item.Shared;

public class ItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ItemCategoryDto ItemCategory { get; set; }
    public int Quantity { get; set; }
    public int MinimumStockQuantity { get; set; }
}