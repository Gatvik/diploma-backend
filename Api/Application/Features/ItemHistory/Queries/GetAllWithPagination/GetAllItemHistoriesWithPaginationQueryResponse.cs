using Api.Application.Features.ItemHistory.Common;

namespace Api.Application.Features.ItemHistory.Queries.GetAllWithPagination;

public class GetAllItemHistoriesWithPaginationQueryResponse
{
    public List<ItemHistoryDto> ItemHistories { get; set; }
    public int Count { get; set; }
}