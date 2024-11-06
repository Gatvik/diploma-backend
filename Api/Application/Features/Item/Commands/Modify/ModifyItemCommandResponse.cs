namespace Api.Application.Features.Item.Commands.Modify;

public class ModifyItemCommandResponse
{
    public Guid ItemId { get; set; }
    public int Remaining { get; set; }
}