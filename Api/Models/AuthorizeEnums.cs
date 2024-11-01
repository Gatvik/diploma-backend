using Api.Data.Models;
using Microsoft.AspNetCore.Authorization;

namespace Api.Application.Attributes;

public class AuthorizeEnumsAttribute : AuthorizeAttribute
{
    public AuthorizeEnumsAttribute(params Roles[] roles)
    {
        Roles = string.Join(",", roles.Select(r => Enum.GetName(typeof(Roles), r)));
    }
}