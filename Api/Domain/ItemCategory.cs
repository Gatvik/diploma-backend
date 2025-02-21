using Api.Domain.Common;

namespace Api.Domain;

public class ItemCategory : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Item> Items { get; set; }
}