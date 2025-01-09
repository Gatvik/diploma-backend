using Api.Application.Exceptions;
using Api.Application.Features.AppRole.Common;
using Api.Data.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Api.Application.Features.AppRole.Queries.GetRoleByName;

public class GetRoleByNameQueryHandler : IRequestHandler<GetRoleByNameQuery, RoleDto>
{
    private readonly RoleManager<Role> _roleManager;
    private readonly IMapper _mapper;

    public GetRoleByNameQueryHandler(RoleManager<Role> roleManager, IMapper mapper)
    {
        _roleManager = roleManager;
        _mapper = mapper;
    }
    
    public async Task<RoleDto> Handle(GetRoleByNameQuery request, CancellationToken cancellationToken)
    {
        var roles = _roleManager.Roles;
        var role = await roles.FirstOrDefaultAsync(r => r.Name == request.Name, cancellationToken: cancellationToken);
        if (role is not null)
            return _mapper.Map<RoleDto>(role);

        throw new NotFoundException("Role not found");
    }
}