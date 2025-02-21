using Api.Application.Features.Item.Queries.GetAllByCategory;
using MediatR;

namespace Api.Application.Features.ItemCategory.Query.GetAll;

public class GetAllItemCategoriesQuery : IRequest<GetAllItemCategoriesQueryResponse>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}