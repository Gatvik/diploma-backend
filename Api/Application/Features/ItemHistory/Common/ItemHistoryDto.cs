using Api.Application.Features.Item.Shared;
using Api.Application.Features.User.Common;

namespace Api.Application.Features.ItemHistory.Common;

public class ItemHistoryDto
{
    public int Value { get; set; }
    public string PerformedAction { get; set; }  // Take, Put
    public DateTime DateOfAction { get; set; }
    
    public ItemDto Item { get; set; }

    public UserDto? User { get; set; }
}