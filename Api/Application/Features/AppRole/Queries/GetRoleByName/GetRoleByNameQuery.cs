using MediatR;

namespace Api.Application.Features.AppRole.Queries.GetRoleByName;

public class GetRoleByNameQuery : IRequest<string>
{
    public string Name { get; set; }
}