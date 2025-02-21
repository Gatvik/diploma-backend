using Api.Domain.Common;

namespace Api.Domain;

public class Item : BaseEntity
{
    public string Name { get; set; }
    public Guid ItemCategoryId { get; set; }
    public ItemCategory ItemCategory { get; set; }
    public int Quantity { get; set; }
    public int MinimumStockQuantity { get; set; }

    public ICollection<ItemHistory> ItemHistories { get; set; }
}