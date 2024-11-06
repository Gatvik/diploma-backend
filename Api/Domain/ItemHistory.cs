using Api.Data.Models;
using Api.Domain.Common;

namespace Api.Domain;

public class ItemHistory : BaseEntity
{
    public int Value { get; set; }
    public string PerformedAction { get; set; }  // Take, Put
    public DateTime DateOfAction { get; set; }
    
    public Guid ItemId { get; set; }
    public Item Item { get; set; }

    public Guid? UserId { get; set; }
    public AppUser? User { get; set; }
}