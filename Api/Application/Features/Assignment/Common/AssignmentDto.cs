using Api.Application.Features.AppRole.Common;
using Api.Data.Models;

namespace Api.Application.Features.Assignment.Common;

public class AssignmentDto
{
    public string Name { get; set; }
    public AppRoleDto Role { get; set; }
}