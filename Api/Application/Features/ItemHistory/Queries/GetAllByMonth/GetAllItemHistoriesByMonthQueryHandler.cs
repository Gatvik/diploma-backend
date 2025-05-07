using System.Linq.Expressions;
using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using Api.Application.Features.ItemHistory.Common;
using AutoMapper;
using MediatR;

namespace Api.Application.Features.ItemHistory.Queries.GetAllByMonth;

public class GetAllItemHistoriesByMonthQueryHandler : IRequestHandler<GetAllItemHistoriesByMonthQuery, List<ItemHistoryDto>>
{
    private readonly IItemHistoryRepository _itemHistoryRepository;
    private readonly IMapper _mapper;

    public GetAllItemHistoriesByMonthQueryHandler(IItemHistoryRepository itemHistoryRepository, IMapper mapper)
    {
        _itemHistoryRepository = itemHistoryRepository;
        _mapper = mapper;
    }
    
    public async Task<List<ItemHistoryDto>> Handle(GetAllItemHistoriesByMonthQuery request, CancellationToken cancellationToken)
    {
        var itemHistories = await _itemHistoryRepository.GetAllByPredicateAsync(x => x.DateOfAction.Month == request.Month, 
            orderBy: r => r.DateOfAction,
            includes: new Expression<Func<Domain.ItemHistory, object>>[] { x => x.Item, x => x.User });

        if (itemHistories.Count == 0)
            throw new NotFoundException("Item history for that month wasn't found");

        return _mapper.Map<List<ItemHistoryDto>>(itemHistories);
    }
}