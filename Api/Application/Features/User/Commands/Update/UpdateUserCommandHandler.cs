using Api.Application.Exceptions;
using Api.Data.Models;
using AutoMapper;
using DocumentFormat.OpenXml.Bibliography;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Api.Application.Features.User.Commands.Update;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
{
    private readonly UserManager<Data.Models.User> _userManager;

    public UpdateUserCommandHandler(UserManager<Data.Models.User> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateUserCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException(validationResult);
        
        var user = await _userManager.FindByIdAsync(request.Id.ToString());
        if (user is null)
            throw new NotFoundException();

        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Sex = request.Sex;

        await _userManager.UpdateAsync(user);
        
        var previousUserRole = (await _userManager.GetRolesAsync(user)).First().ToUpper();
        var newRole = request.Role.ToUpper();
        if (previousUserRole != request.Role)
        {
            await _userManager.RemoveFromRoleAsync(user, previousUserRole);
            await _userManager.AddToRoleAsync(user, request.Role);
        }

        return Unit.Value;
    }
}