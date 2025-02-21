using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using Api.Application.Features.Item.Shared;
using AutoMapper;
using MediatR;

namespace Api.Application.Features.Item.Queries.GetLackingItems;

public class GetLackingItemsQueryHandler : IRequestHandler<GetLackingItemsQuery, List<LackingItemDto>>
{
    private readonly IItemRepository _itemRepository;
    private readonly IMapper _mapper;

    public GetLackingItemsQueryHandler(IItemRepository itemRepository, IMapper mapper)
    {
        _itemRepository = itemRepository;
        _mapper = mapper;
    }
    
    public async Task<List<LackingItemDto>> Handle(GetLackingItemsQuery request, CancellationToken cancellationToken)
    {
        var items = await _itemRepository.GetAllByPredicateAsync(predicate: i => i.Quantity < i.MinimumStockQuantity,
            includes: i => i.ItemCategory,
            orderBy: x => x.Name);
        if (items.Count == 0)
            throw new NotFoundException();
        
        return _mapper.Map<List<LackingItemDto>>(items);
    }
}