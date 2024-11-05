using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using AutoMapper;
using MediatR;

namespace Api.Application.Features.Item.Commands.Update;

public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IItemRepository _itemRepository;

    public UpdateItemCommandHandler(IMapper mapper, IItemRepository itemRepository)
    {
        _mapper = mapper;
        _itemRepository = itemRepository;
    }
    
    public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var item = await _itemRepository.GetByIdAsync(request.Id);
        if (item is null)
            throw new NotFoundException();
        
        var validator = new UpdateItemCommandValidator(_itemRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new BadRequestException(validationResult);

        var newItem = _mapper.Map<Domain.Item>(request);
        
        await _itemRepository.UpdateAsync(newItem);
        return Unit.Value;
    }
}