using Api.Application.Features.AppRole.Common;
using MediatR;

namespace Api.Application.Features.AppRole.Queries.GetRoles;

public class GetRolesQuery : IRequest<List<RoleDto>>
{
    
}