using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using Api.Application.Features.Item.Shared;
using AutoMapper;
using MediatR;

namespace Api.Application.Features.Item.Queries.GetAll;

public class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, GetAllItemsQueryResponse>
{
    private readonly IItemRepository _itemRepository;
    private readonly IMapper _mapper;

    public GetAllItemsQueryHandler(IItemRepository itemRepository, IMapper mapper)
    {
        _itemRepository = itemRepository;
        _mapper = mapper;
    }
    
    public async Task<GetAllItemsQueryResponse> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
    {
        var items = await _itemRepository.GetAllAsync(pageNumber: request.PageNumber, pageSize: request.PageSize, 
            includes: i => i.ItemCategory,
            orderBy: x => x.Name);

        if (items.Count <= 0)
            throw new NotFoundException();

        var response = new GetAllItemsQueryResponse
        {
            Items = _mapper.Map<List<ItemDto>>(items),
            Count = _itemRepository.Count()
        };
        
        return response;
    }
}