using Api.Application.Features.AssignmentToUser.Create;
using Api.Domain;
using AutoMapper;

namespace Api.Application.MappingProfiles;

public class AssignmentToUserMappingProfile : Profile
{
    public AssignmentToUserMappingProfile()
    {
        CreateMap<CreateAssignmentToUserCommand, AssignmentToUser>();
    }
}