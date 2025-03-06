using Api.Application.Features.AssignmentToUserStatus.Common;
using Api.Domain;
using AutoMapper;

namespace Api.Application.MappingProfiles;

public class AssignmentToUserStatusMappingProfile : Profile
{
    public AssignmentToUserStatusMappingProfile()
    {
        CreateMap<AssignmentToUserStatus, AssignmentToUserStatusDto>();
    }
}