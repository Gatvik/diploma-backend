using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using MediatR;

namespace Api.Application.Features.Item.Commands.Delete;

public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, Unit>
{
    private readonly IItemRepository _itemRepository;

    public DeleteItemCommandHandler(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }
    
    public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        var item = await _itemRepository.GetByIdAsync(request.ItemId);

        if (item is null)
            throw new NotFoundException();

        await _itemRepository.DeleteAsync(item);
        return Unit.Value;
    }
}