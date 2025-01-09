using Api.Application.Features.AppRole.Common;
using MediatR;

namespace Api.Application.Features.AppRole.Queries.GetRoleByName;

public class GetRoleByNameQuery : IRequest<RoleDto>
{
    public string Name { get; set; }
}