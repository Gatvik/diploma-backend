using System.Text;
using Api.Application.Exceptions;
using Api.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Api.Application.Features.User.Commands.ConfirmPasswordRecovery;

public class ConfirmPasswordRecoveryCommandHandler : IRequestHandler<ConfirmPasswordRecoveryCommand, Unit>
{
    private readonly UserManager<AppUser> _userManager;

    public ConfirmPasswordRecoveryCommandHandler(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task<Unit> Handle(ConfirmPasswordRecoveryCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            throw new BadRequestException("Invalid data");
        }

        var result = await _userManager.ResetPasswordAsync(user, request.Code, request.NewPassword);
        if (!result.Succeeded)
        {
            StringBuilder str = new StringBuilder();
            foreach (var err in result.Errors)
            {
                str.Append($"{err.Description}");
            }
                
            throw new BadRequestException(str.ToString());
        }

        return Unit.Value;
    }
}