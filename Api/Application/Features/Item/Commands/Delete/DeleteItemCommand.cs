using MediatR;

namespace Api.Application.Features.Item.Commands.Delete;

public class DeleteItemCommand : IRequest<Unit>
{
    public Guid ItemId { get; set; }
}