using Api.Data.Models;
using FluentValidation;

namespace Api.Application.Features.Authentication.Commands.Register;

public class RegistrationCommandValidator : AbstractValidator<RegistrationCommand>
{
    public RegistrationCommandValidator()
    {
        RuleFor(m => m.FirstName)
            .NotEmpty().WithMessage("Can't be empty")
            .MaximumLength(64).WithMessage("Must be fewer than {ComparisonValue} characters");
        
        RuleFor(m => m.LastName)
            .NotEmpty().WithMessage("Can't be empty")
            .MaximumLength(64).WithMessage("Must be fewer than {ComparisonValue} characters");

        RuleFor(m => m.Email)
            .EmailAddress().WithMessage("Invalid format");

        RuleFor(p => p.Sex)
            .Must(MustBeValidSexValue).WithMessage("Can only have \"male\" or \"female\" values.");
        
        RuleFor(p => p.Role)
            .Must(MustBeValidRoleValue).WithMessage("Invalid format");
    }

    private bool MustBeValidSexValue(string sex)
    {
        return sex is "male" or "female";
    }
    
    private bool MustBeValidRoleValue(string role)
    {
        var isParsed = Enum.TryParse<Roles>(role, true, out _);

        return isParsed;
    }
}