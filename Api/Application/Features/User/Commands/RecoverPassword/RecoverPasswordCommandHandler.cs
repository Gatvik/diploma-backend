using Api.Application.Contracts.Infrastructure;
using Api.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Api.Application.Features.User.Commands.RecoverPassword;

public class RecoverPasswordCommandHandler : IRequestHandler<RecoverPasswordCommand, Unit>
{
    private readonly UserManager<Data.Models.User> _userManager;
    private readonly IEmailService _emailService;

    public RecoverPasswordCommandHandler(UserManager<Data.Models.User> userManager, IEmailService emailService)
    {
        _userManager = userManager;
        _emailService = emailService;
    }
    
    public async Task<Unit> Handle(RecoverPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        
        if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            return Unit.Value; // Do not reveal either user registered is or not
        
        var code = await _userManager.GeneratePasswordResetTokenAsync(user);
        // TODO: Enable emails
        Console.WriteLine(code);
        await _emailService.SendPasswordRecoveryCode(user.Email!, code);

        return Unit.Value;
    }
}