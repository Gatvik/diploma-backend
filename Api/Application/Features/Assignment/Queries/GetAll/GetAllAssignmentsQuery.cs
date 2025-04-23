using Api.Application.Features.Assignment.Common;
using MediatR;

namespace Api.Application.Features.Assignment.Queries.GetAll;

public class GetAllAssignmentsQuery : IRequest<GetAllAssignmentsQueryResponse>
{
    public int? PageNumber { get; set; }
    public int? PageSize { get; set; }
}