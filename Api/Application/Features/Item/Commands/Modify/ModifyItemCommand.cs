using MediatR;

namespace Api.Application.Features.Item.Commands.Modify;

public class ModifyItemCommand : IRequest<ModifyItemCommandResponse>
{
    public Guid ItemId { get; set; }
    public int Amount { get; set; }
}