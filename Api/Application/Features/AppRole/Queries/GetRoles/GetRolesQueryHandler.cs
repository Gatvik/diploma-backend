using Api.Application.Exceptions;
using Api.Data.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Api.Application.Features.AppRole.Queries.GetRoles;

public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, string[]>
{
    public GetRolesQueryHandler(RoleManager<Role> roleManager)
    {
    }
    
    public async Task<string[]> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = Enum.GetNames<Roles>();
        if (roles.Length == 0)
            throw new NotFoundException("Roles not found");

        return roles;
    }
}