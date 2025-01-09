using Api.Application.Exceptions;
using Api.Application.Features.AppRole.Common;
using Api.Data.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Api.Application.Features.AppRole.Queries.GetRoles;

public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, List<RoleDto>>
{
    private readonly RoleManager<Role> _roleManager;
    private readonly IMapper _mapper;

    public GetRolesQueryHandler(RoleManager<Role> roleManager, IMapper mapper)
    {
        _roleManager = roleManager;
        _mapper = mapper;
    }
    
    public async Task<List<RoleDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = _roleManager.Roles;
        if (!roles.Any())
            throw new NotFoundException("Roles not found");

        return _mapper.Map<List<RoleDto>>(roles);
    }
}