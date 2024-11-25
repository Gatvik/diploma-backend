using Api.Application.Contracts.Identity;
using Api.Application.Exceptions;
using Api.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Api.Application.Features.User.Commands.ConfirmEmail;

public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, Unit>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IUserService _userService;

    public ConfirmEmailCommandHandler(UserManager<AppUser> userManager, IUserService userService)
    {
        this._userManager = userManager;
        _userService = userService;
    }
    
    public async Task<Unit> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(_userService.UserId);
        var result = await _userManager.VerifyTwoFactorTokenAsync(user!, "Email", request.ValidationCode);
        if (!result) 
            throw new BadRequestException("Invalid confirmation code");
        
        user.EmailConfirmed = true;
        await _userManager.UpdateAsync(user);
        return Unit.Value;
    }
}