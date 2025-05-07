using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using Api.Application.Features.Item.Shared;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Api.Application.Features.ItemHistory.Queries.GetMostPopularItem;

public class GetMostPopularItemQueryHandler : IRequestHandler<GetMostPopularItemQuery, GetMostPopularItemResponse>
{
    private readonly IItemHistoryRepository _itemHistoryRepository;
    private readonly IItemRepository _itemRepository;
    private readonly IMapper _mapper;

    public GetMostPopularItemQueryHandler(IItemHistoryRepository itemHistoryRepository, IItemRepository itemRepository, IMapper mapper)
    {
        _itemHistoryRepository = itemHistoryRepository;
        _itemRepository = itemRepository;
        _mapper = mapper;
    }
    
    public async Task<GetMostPopularItemResponse> Handle(GetMostPopularItemQuery request, CancellationToken cancellationToken)
    {
        var itemData = await _itemHistoryRepository.Context.ItemsHistories.GroupBy(h => h.ItemId)
            .Select(g => new
            {
                ItemId = g.Key,
                InteractionCount = g.Count()
            })
            .OrderByDescending(g => g.InteractionCount)
            .FirstOrDefaultAsync();

        if (itemData is null)
            throw new NotFoundException("No data about item histories");
        
        var item = await _itemRepository.GetByIdAsync(itemData.ItemId, includes: i => i.ItemCategory);

        return new GetMostPopularItemResponse
            { Item = _mapper.Map<ItemDto>(item), Interactions = itemData.InteractionCount };
    }
}