using Api.Application.Features.Item.Shared;
using MediatR;

namespace Api.Application.Features.Item.Queries.GetAllByCategory;

public class GetAllItemsByCategoryQuery : IRequest<GetAllItemsByCategoryQueryResponse>
{
    public Guid CategoryId { get; set; }
    public required int PageNumber { get; set; }
    public required int PageSize { get; set; }
}