using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Api.Application.Contracts.Infrastructure;
using Api.Application.Exceptions;
using Api.Application.Features.Authentication.Shared;
using Api.Data.Models;
using Api.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Api.Application.Features.Authentication.Commands.Register;

public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, RegistrationResponse>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IEmailService _emailService;
    private readonly JwtSettings _jwtSettings;

    public RegistrationCommandHandler(UserManager<AppUser> userManager, IOptions<JwtSettings> jwtSettings, IEmailService emailService)
    {
        _userManager = userManager;
        _emailService = emailService;
        _jwtSettings = jwtSettings.Value;
    }
    
    public async Task<RegistrationResponse> Handle(RegistrationCommand request, CancellationToken cancellationToken)
    {
        var validator = new RegistrationCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new BadRequestException(validationResult);
        
        var user = new AppUser
        {
            Email = request.Email,
            UserName = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Sex = request.Sex,
            EmailConfirmed = false
        };

        var password = PasswordGenerator.GeneratePassword();
        var result = await _userManager.CreateAsync(user, password);
        if (!result.Succeeded)
        {
            StringBuilder str = new StringBuilder();
            foreach (var err in result.Errors)
            {
                str.Append($"{err.Description}");
            }
                
            throw new BadRequestException(str.ToString());
        }
        
        var code = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");

        // TODO: Enable emails
        Console.WriteLine(code);
        Console.WriteLine(password);
        // await _emailService.SendEmailConfirmationCode(request.Email, password, code);
        
        await _userManager.AddToRoleAsync(user, request.Role);
        
        JwtSecurityToken jwtSecurityToken = await new JwtTokenGenerator(_userManager, _jwtSettings).GenerateTokenAsync(user);
        
        return new RegistrationResponse
        {
            UserId = user.Id.ToString(), 
            //Bearer = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
        };
    }
}