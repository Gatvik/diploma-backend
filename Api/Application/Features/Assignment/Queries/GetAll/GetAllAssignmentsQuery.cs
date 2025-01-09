using Api.Application.Features.Assignment.Common;
using MediatR;

namespace Api.Application.Features.Assignment.Queries.GetAll;

public class GetAllAssignmentsQuery : IRequest<List<AssignmentDto>>
{
    
}