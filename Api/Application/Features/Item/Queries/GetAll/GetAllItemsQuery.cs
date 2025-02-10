using Api.Application.Features.Item.Shared;
using MediatR;

namespace Api.Application.Features.Item.Queries.GetAll;

public class GetAllItemsQuery : IRequest<GetAllItemsQueryResponse>
{
    public required int PageNumber { get; set; }
    public required int PageSize { get; set; }
}