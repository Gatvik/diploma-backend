using System.IdentityModel.Tokens.Jwt;
using Api.Application.Exceptions;
using Api.Application.Features.Authentication.Shared;
using Api.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Api.Application.Features.Authentication.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly JwtSettings _jwtSettings;

    public LoginCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
        IOptions<JwtSettings> jwtSettings)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var validator = new LoginCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException("Data for login was invalid", validationResult);
        
        var user = await _userManager.FindByEmailAsync(request.Email);
        var allUsers = _userManager.Users;

        if (user == null)
        {
            throw new NotFoundException($"User with email {request.Email} was not found.");
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (result.Succeeded == false)
        {
            throw new BadRequestException($"Credentials for {request.Email} aren't valid");
        }

        JwtSecurityToken jwtSecurityToken = await new JwtTokenGenerator(_userManager, _jwtSettings).GenerateTokenAsync(user);
        var roles = await _userManager.GetRolesAsync(user);

        var response = new LoginResponse
        {
            UserId = user.Id.ToString(),
            Bearer = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            EmailConfirmed = user.EmailConfirmed,
            Role = roles[0]
        };

        return response;
    }

    
}