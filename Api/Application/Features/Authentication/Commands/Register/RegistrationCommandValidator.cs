using Api.Data.Models;
using FluentValidation;

namespace Api.Application.Features.Authentication.Commands.Register;

public class RegistrationCommandValidator : AbstractValidator<RegistrationCommand>
{
    public RegistrationCommandValidator()
    {
        RuleFor(m => m.FirstName)
            .NotEmpty().WithMessage("{PropertyName} can't be empty")
            .MaximumLength(64).WithMessage("{PropertyName} must be fewer than {ComparisonValue} characters");
        
        RuleFor(m => m.LastName)
            .NotEmpty().WithMessage("{PropertyName} can't be empty")
            .MaximumLength(64).WithMessage("{PropertyName} must be fewer than {ComparisonValue} characters");

        RuleFor(m => m.Email)
            .EmailAddress().WithMessage("Email is not valid");

        RuleFor(p => p.Sex)
            .Must(MustBeValidSexValue).WithMessage("{PropertyName} can only have \"male\" or \"female\" values.");
        
        RuleFor(p => p.Role)
            .Must(MustBeValidRoleValue).WithMessage("{PropertyName} can only have \"male\" or \"female\" values.");
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