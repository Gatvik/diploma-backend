using Api.Application.Features.AppRole.Common;
using Api.Application.Features.Assignment.Commands;
using Api.Application.Features.Assignment.Commands.CreateAssignmentCommand;
using Api.Data.Models;
using Api.Domain;
using AutoMapper;

namespace Api.Application.MappingProfiles;

public class RoleMappingProfile : Profile
{
    public RoleMappingProfile()
    {
        CreateMap<Role, RoleDto>();
        CreateMap<CreateAssignmentCommand, Assignment>();
    }
}