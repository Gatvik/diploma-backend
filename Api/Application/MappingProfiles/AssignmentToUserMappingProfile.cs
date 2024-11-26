using Api.Application.Features.AssignmentToUser.Commands.Create;
using Api.Application.Features.AssignmentToUser.Common;
using Api.Domain;
using AutoMapper;

namespace Api.Application.MappingProfiles;

public class AssignmentToUserMappingProfile : Profile
{
    public AssignmentToUserMappingProfile()
    {
        CreateMap<CreateAssignmentToUserCommand, AssignmentToUser>();
        CreateMap<AssignmentToUser, AssignmentToUserDto>();
    }
}