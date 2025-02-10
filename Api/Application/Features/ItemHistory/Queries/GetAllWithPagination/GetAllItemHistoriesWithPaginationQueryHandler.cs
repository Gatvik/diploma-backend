using System.Linq.Expressions;
using Api.Application.Contracts.Persistence;
using Api.Application.Features.ItemHistory.Common;
using Api.Data.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Application.Features.ItemHistory.Queries.GetAllWithPagination;

public class GetAllItemHistoriesWithPaginationQueryHandler : IRequestHandler<GetAllItemHistoriesWithPaginationQuery, GetAllItemHistoriesWithPaginationQueryResponse>
{
    private readonly IItemHistoryRepository _itemHistoryRepository;
    private readonly IMapper _mapper;

    public GetAllItemHistoriesWithPaginationQueryHandler(IItemHistoryRepository itemHistoryRepository, IMapper mapper)
    {
        _itemHistoryRepository = itemHistoryRepository;
        _mapper = mapper;
    }

    public async Task<GetAllItemHistoriesWithPaginationQueryResponse> Handle(GetAllItemHistoriesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var itemHistories = await _itemHistoryRepository.GetAllAsync(
            pageSize: request.PageSize, pageNumber: request.PageNumber,
            orderBy: r => r.DateOfAction, 
            includes: new Expression<Func<Domain.ItemHistory, object>>[] { x => x.Item, x => x.User });

        var response = new GetAllItemHistoriesWithPaginationQueryResponse
        {
            ItemHistories = _mapper.Map<List<ItemHistoryDto>>(itemHistories),
            Count = _itemHistoryRepository.Count()
        };

        return response;
    }
}