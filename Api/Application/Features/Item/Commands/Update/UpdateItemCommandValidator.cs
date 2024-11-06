using Api.Application.Contracts.Persistence;
using FluentValidation;

namespace Api.Application.Features.Item.Commands.Update;

public class UpdateItemCommandValidator : AbstractValidator<UpdateItemCommand>
{
    private readonly IItemRepository _itemRepository;

    public UpdateItemCommandValidator(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
        RuleFor(i => i.Name)
            .NotEmpty().WithMessage("Must be provided")
            .MaximumLength(64).WithMessage("Must be shorter than {ComparisonValue}")
            .MustAsync(MustBeUnique).WithMessage("Must be unique");
        
        RuleFor(i => i.MinimumStockQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("Must be greater than or equal to 0")
            .LessThanOrEqualTo(int.MaxValue).WithMessage("Can't be greater than {ComparisonValue}");
    }

    private async Task<bool> MustBeUnique(UpdateItemCommand command, string name, CancellationToken ct)
    {
        var item = await _itemRepository.GetByPredicateAsync(i => i.Name == name);
        if (item is not null)
        {
            var itemById = await _itemRepository.GetByIdAsync(command.Id);

            return item.Id == itemById!.Id;
        }

        return item is null;
    }
}