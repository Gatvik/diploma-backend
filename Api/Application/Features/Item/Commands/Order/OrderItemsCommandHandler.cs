using Api.Application.Contracts.Identity;
using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using Api.Domain;
using MediatR;

namespace Api.Application.Features.Item.Commands.Order;

public class OrderItemsCommandHandler : IRequestHandler<OrderItemsCommand, Unit>
{
    private readonly IItemRepository _itemRepository;
    private readonly IItemHistoryRepository _itemHistoryRepository;
    private readonly IUserService _userService;

    public OrderItemsCommandHandler(IItemRepository itemRepository, IItemHistoryRepository itemHistoryRepository, IUserService userService)
    {
        _itemRepository = itemRepository;
        _itemHistoryRepository = itemHistoryRepository;
        _userService = userService;
    }
    
    public async Task<Unit> Handle(OrderItemsCommand request, CancellationToken cancellationToken)
    {
        var validator = new OrderItemsCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException(validationResult);

        List<Domain.Item> itemsToUpdate = new List<Domain.Item>(request.ItemsToOrder.Length);
        List<Domain.ItemHistory> itemHistories = new List<Domain.ItemHistory>(request.ItemsToOrder.Length);
        var inventoryManagerId = _userService.UserId;
        foreach (var orderItem in request.ItemsToOrder)
        {
            var item = await _itemRepository.GetByPredicateAsync(i => i.Name == orderItem.Name);
            if (item is null)
                throw new NotFoundException($"Item {orderItem.Name} was not found");

            item.Quantity += orderItem.Quantity;
            
            var itemHistory = new Domain.ItemHistory
            {
                DateOfAction = DateTime.UtcNow,
                ItemId = item.Id,
                PerformedAction = "Put",
                UserId = Guid.Parse(inventoryManagerId),
                Value = orderItem.Quantity
            };
            
            itemHistories.Add(itemHistory);
            itemsToUpdate.Add(item);
        }

        await _itemRepository.UpdateRangeAsync(itemsToUpdate);
        await _itemHistoryRepository.CreateRangeAsync(itemHistories);
        
        return Unit.Value;
    }
}