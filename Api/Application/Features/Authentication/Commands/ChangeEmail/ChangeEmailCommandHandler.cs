using Api.Application.Contracts.Identity;
using Api.Application.Exceptions;
using Api.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Api.Application.Features.Authentication.Commands.ChangeEmail;

public class ChangeEmailCommandHandler : IRequestHandler<ChangeEmailCommand, Unit>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IUserService _userService;

    public ChangeEmailCommandHandler(UserManager<AppUser> userManager, IUserService userService)
    {
        _userManager = userManager;
        _userService = userService;
    }
    
    public async Task<Unit> Handle(ChangeEmailCommand request, CancellationToken cancellationToken)
    {
        var userId = _userService.UserId;
        var user = await _userManager.FindByIdAsync(userId);

        // var validationResult = await new ChangeEmailCommandValidator(_userManager).ValidateAsync(request, cancellationToken);
        // if (!validationResult.IsValid)
        //     throw new BadRequestException("Invalid email address", validationResult);
        
        var changeUserNameResult = await _userManager.SetUserNameAsync(user, request.NewEmail);
        if (!changeUserNameResult.Succeeded)
            throw new ArgumentException("Change username operation went wrong, but it's impossible");
        
        var emailToken = await _userManager.GenerateChangeEmailTokenAsync(user!, request.NewEmail);
        var changeEmailResult = await _userManager.ChangeEmailAsync(user, request.NewEmail, emailToken);
        if (!changeEmailResult.Succeeded)
            throw new ArgumentException("Change email operation went wrong, but it's impossible");

        return Unit.Value;
    }
}