using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using Api.Application.Features.Item.Shared;
using AutoMapper;
using MediatR;

namespace Api.Application.Features.Item.Queries.GetAllByCategory;

public class GetAllItemsByCategoryQueryHandler : IRequestHandler<GetAllItemsByCategoryQuery, GetAllItemsByCategoryQueryResponse>
{
    private readonly IItemRepository _itemRepository;
    private readonly IMapper _mapper;

    public GetAllItemsByCategoryQueryHandler(IItemRepository itemRepository, IMapper mapper)
    {
        _itemRepository = itemRepository;
        _mapper = mapper;
    }
    
    public async Task<GetAllItemsByCategoryQueryResponse> Handle(GetAllItemsByCategoryQuery request, CancellationToken cancellationToken)
    {
        var items = await _itemRepository.GetAllByPredicateAsync(i => i.ItemCategoryId == request.CategoryId, 
            request.PageNumber, request.PageSize);
        if (items.Count == 0)
            throw new NotFoundException("Items with that category wasn't found");
        
        var response = new GetAllItemsByCategoryQueryResponse
        {
            Items = _mapper.Map<List<ItemDto>>(items),
            Count = _itemRepository.Count(i => i.ItemCategoryId == request.CategoryId)
        };
        
        return response;
    }
}