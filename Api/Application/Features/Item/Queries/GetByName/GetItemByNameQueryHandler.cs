using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using Api.Application.Features.Item.Shared;
using AutoMapper;
using MediatR;

namespace Api.Application.Features.Item.Queries.GetByName;

public class GetItemByNameQueryHandler : IRequestHandler<GetItemByNameQuery, ItemDto>
{
    private readonly IItemRepository _itemRepository;
    private readonly IMapper _mapper;

    public GetItemByNameQueryHandler(IItemRepository itemRepository, IMapper mapper)
    {
        _itemRepository = itemRepository;
        _mapper = mapper;
    }
    
    public async Task<ItemDto> Handle(GetItemByNameQuery request, CancellationToken cancellationToken)
    {
        var item = await _itemRepository.GetByPredicateAsync(i => i.Name == request.ItemName);

        if (item is null)
            throw new NotFoundException("Item not found");

        return _mapper.Map<ItemDto>(item);
    }
}