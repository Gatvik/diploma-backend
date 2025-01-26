﻿using Api.Application.Features.ItemHistory.Common;
using MediatR;

namespace Api.Application.Features.ItemHistory.Queries.GetAllWithPagination;

public class GetAllItemHistoriesWithPaginationQuery : IRequest<List<ItemHistoryDto>>
{
    public int PageNumber { get; set; } 
    public int PageSize { get; set; }
}