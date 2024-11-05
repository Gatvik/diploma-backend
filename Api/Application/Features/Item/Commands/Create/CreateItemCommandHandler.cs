using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Api.Application.Features.Item.Commands.Create;

public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, Unit>
{
    private readonly IItemRepository _itemRepository;
    private readonly IMapper _mapper;

    public CreateItemCommandHandler(IItemRepository itemRepository, IMapper mapper)
    {
        _itemRepository = itemRepository;
        _mapper = mapper;
    }
    
    public async Task<Unit> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateItemCommandValidator(_itemRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new BadRequestException(validationResult);
        
        var item = _mapper.Map<Domain.Item>(request);
        
        await _itemRepository.CreateAsync(item);
        
        return Unit.Value;
    }
}