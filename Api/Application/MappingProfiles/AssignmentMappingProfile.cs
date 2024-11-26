using Api.Application.Features.Assignment.Common;
using Api.Domain;
using AutoMapper;

namespace Api.Application.MappingProfiles;

public class AssignmentMappingProfile : Profile
{
    public AssignmentMappingProfile()
    {
        CreateMap<Assignment, AssignmentDto>();
    }
}