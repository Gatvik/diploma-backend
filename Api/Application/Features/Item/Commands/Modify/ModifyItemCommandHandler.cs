using Api.Application.Contracts.Identity;
using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using Api.Data.Models;
using Api.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Api.Application.Features.Item.Commands.Modify;

public class ModifyItemCommandHandler : IRequestHandler<ModifyItemCommand, ModifyItemCommandResponse>
{
    private readonly IItemRepository _itemRepository;
    private readonly IItemHistoryRepository _itemHistoryRepository;
    private readonly IUserService _userService;
    private readonly UserManager<AppUser> _userManager;

    public ModifyItemCommandHandler(IItemRepository itemRepository, IItemHistoryRepository itemHistoryRepository, 
        IUserService userService,
        UserManager<AppUser> userManager)
    {
        _itemRepository = itemRepository;
        _itemHistoryRepository = itemHistoryRepository;
        _userService = userService;
        _userManager = userManager;
    }
    
    public async Task<ModifyItemCommandResponse> Handle(ModifyItemCommand request, CancellationToken cancellationToken)
    {
        var validator = new ModifyItemCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException(validationResult);
        
        var item = await _itemRepository.GetByIdAsync(request.ItemId);
        if (item is null)
            throw new NotFoundException();
        
        var resultAmount = item.Quantity + request.Amount;
        if (resultAmount < 0)
            throw new BadRequestException("Can't take more than what's left");
        
        var performedAction = request.Amount > 0 ? "Put" : "Take";
        var user = await _userManager.FindByIdAsync(_userService.UserId);
        
        item.Quantity = resultAmount;
        await _itemRepository.UpdateAsync(item);

        var itemHistory = new ItemHistory
        {
            DateOfAction = DateTime.UtcNow,
            ItemId = item.Id,
            PerformedAction = performedAction,
            UserId = user!.Id,
            Value = request.Amount
        };
        await _itemHistoryRepository.CreateAsync(itemHistory);
        
        return new ModifyItemCommandResponse
        {
            ItemId = item.Id,
            Remaining = resultAmount
        };
    }
}