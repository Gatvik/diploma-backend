using Api.Application.Features.AppRole.Common;
using Api.Data.Models;
using AutoMapper;

namespace Api.Application.MappingProfiles;

public class AppRoleMappingProfile : Profile
{
    public AppRoleMappingProfile()
    {
        CreateMap<AppRole, AppRoleDto>();
    }
}