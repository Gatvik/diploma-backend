using Api.Application.Features.User.Common;
using Api.Data.Models;
using AutoMapper;

namespace Api.Application.MappingProfiles;

public class AppUserMappingProfile : Profile
{
    public AppUserMappingProfile()
    {
        CreateMap<User, UserDto>();
    }
}