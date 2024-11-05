using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using Api.Application.Features.Item.Shared;
using AutoMapper;
using MediatR;

namespace Api.Application.Features.Item.Queries.GetAll;

public class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, List<ItemDto>>
{
    private readonly IItemRepository _itemRepository;
    private readonly IMapper _mapper;

    public GetAllItemsQueryHandler(IItemRepository itemRepository, IMapper mapper)
    {
        _itemRepository = itemRepository;
        _mapper = mapper;
    }
    
    public async Task<List<ItemDto>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
    {
        var items = await _itemRepository.GetAllAsync();

        if (items.Count <= 0)
            throw new NotFoundException();

        return _mapper.Map<List<ItemDto>>(items);
    }
}