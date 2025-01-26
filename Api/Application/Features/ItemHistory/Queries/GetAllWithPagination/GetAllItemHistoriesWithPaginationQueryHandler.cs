using Api.Application.Contracts.Persistence;
using Api.Application.Features.ItemHistory.Common;
using Api.Data.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Application.Features.ItemHistory.Queries.GetAllWithPagination;

public class GetAllItemHistoriesWithPaginationQueryHandler : IRequestHandler<GetAllItemHistoriesWithPaginationQuery, List<ItemHistoryDto>>
{
    private readonly IItemHistoryRepository _itemHistoryRepository;
    private readonly IMapper _mapper;

    public GetAllItemHistoriesWithPaginationQueryHandler(IItemHistoryRepository itemHistoryRepository, IMapper mapper)
    {
        _itemHistoryRepository = itemHistoryRepository;
        _mapper = mapper;
    }

    public async Task<List<ItemHistoryDto>> Handle(GetAllItemHistoriesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var query = _itemHistoryRepository.GetAllAsQueryable(includes => includes.Item, 
            includes => includes.User);
        
        var paginatedItemHistories = await query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .OrderBy(r => r.DateOfAction)
            .ToListAsync(cancellationToken);

        return _mapper.Map<List<ItemHistoryDto>>(paginatedItemHistories);
    }
}