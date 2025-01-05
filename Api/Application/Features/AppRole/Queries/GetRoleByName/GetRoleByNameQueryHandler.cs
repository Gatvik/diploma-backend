using Api.Application.Exceptions;
using Api.Data.Models;
using MediatR;

namespace Api.Application.Features.AppRole.Queries.GetRoleByName;

public class GetRoleByNameQueryHandler : IRequestHandler<GetRoleByNameQuery, string>
{
    public async Task<string> Handle(GetRoleByNameQuery request, CancellationToken cancellationToken)
    {
        var roles = Enum.GetNames<Roles>();
        if (roles.Contains(request.Name))
            return request.Name;

        throw new NotFoundException("Role not found");
    }
}