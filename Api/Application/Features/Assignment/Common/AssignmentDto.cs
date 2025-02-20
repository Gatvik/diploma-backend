using Api.Application.Features.AppRole.Common;
using Api.Data.Models;

namespace Api.Application.Features.Assignment.Common;

public class AssignmentDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public RoleDto Role { get; set; }
}