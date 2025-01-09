using Api.Application.Features.User.Common;
using Api.Data.Models;
using AutoMapper;

namespace Api.Application.MappingProfiles;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserDto>();
    }
}