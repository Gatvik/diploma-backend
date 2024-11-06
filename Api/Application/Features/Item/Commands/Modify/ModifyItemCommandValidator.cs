using FluentValidation;

namespace Api.Application.Features.Item.Commands.Modify;

public class ModifyItemCommandValidator : AbstractValidator<ModifyItemCommand>
{
    public ModifyItemCommandValidator()
    {
        RuleFor(c => c.Amount)
            .NotEqual(0).WithMessage("Can't be equal to 0");
    }
}