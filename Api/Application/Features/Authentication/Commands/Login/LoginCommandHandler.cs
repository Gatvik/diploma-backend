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
    private readonly SignInManager<Data.Models.User> _signInManager;
    private readonly UserManager<Data.Models.User> _userManager;
    private readonly JwtSettings _jwtSettings;

    public LoginCommandHandler(UserManager<Data.Models.User> userManager, SignInManager<Data.Models.User> signInManager,
        IOptions<JwtSettings> jwtSettings)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user is null)
        {
            throw new BadRequestException("Login or password are invalid");
        }
        
        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (!result.Succeeded)
        {
            throw new BadRequestException("Login or password are invalid");
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