using Api.Application.Features.ItemHistory.Common;
using MediatR;

namespace Api.Application.Features.ItemHistory.Queries.GetAllByMonth;

public class GetAllItemHistoriesByMonthQuery : IRequest<List<ItemHistoryDto>>
{
    public int Month { get; set; }
}