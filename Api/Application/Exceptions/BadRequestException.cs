using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace Api.Application.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message) : base(message)
    {
        
    }

    public BadRequestException(ValidationResult validationResult)
    {
        ValidationErrors = validationResult.ToDictionary();
    }
    
    public IDictionary<string, string[]>? ValidationErrors { get; set; }
}