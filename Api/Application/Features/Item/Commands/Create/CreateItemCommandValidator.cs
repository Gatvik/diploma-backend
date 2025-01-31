using Api.Application.Contracts.Persistence;
using FluentValidation;

namespace Api.Application.Features.Item.Commands.Create;

public class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
{
    private readonly IItemRepository _itemRepository;

    public CreateItemCommandValidator(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
        RuleFor(i => i.Name)
            .NotEmpty().WithMessage("Must be provided")
            .MaximumLength(64).WithMessage("Must be shorter than {ComparisonValue}")
            .MustAsync(MustBeUnique).WithMessage("Must be unique");

        RuleFor(i => i.Quantity)
            .GreaterThanOrEqualTo(0).WithMessage("Must be greater than or equal to 0")
            .LessThanOrEqualTo(int.MaxValue).WithMessage("Can't be greater than {ComparisonValue}");
        
        RuleFor(i => i.MinimumStockQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("Must be greater than or equal to 0")
            .LessThanOrEqualTo(int.MaxValue).WithMessage("Can't be greater than {ComparisonValue}");
    }

    private async Task<bool> MustBeUnique(string name, CancellationToken ct)
    {
        var item = await _itemRepository.GetSingleByPredicateAsync(i => i.Name == name);

        return item is null;
    }
}