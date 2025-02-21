using Api.Application.Contracts.Persistence;
using Api.Application.Exceptions;
using Api.Application.Features.Item.Queries.GetAllByCategory;
using Api.Application.Features.ItemCategory.Common;
using AutoMapper;
using MediatR;

namespace Api.Application.Features.ItemCategory.Query.GetAll;

public class GetAllItemCategoriesQueryHandler : IRequestHandler<GetAllItemCategoriesQuery, GetAllItemCategoriesQueryResponse>
{
    private readonly IItemCategoryRepository _itemCategoryRepository;
    private readonly IMapper _mapper;

    public GetAllItemCategoriesQueryHandler(IItemCategoryRepository itemCategoryRepository, IMapper mapper)
    {
        _itemCategoryRepository = itemCategoryRepository;
        _mapper = mapper;
    }
    
    public async Task<GetAllItemCategoriesQueryResponse> Handle(GetAllItemCategoriesQuery request, CancellationToken cancellationToken)
    {
        var itemCategories = await _itemCategoryRepository.GetAllAsync(request.PageNumber, request.PageSize,
            orderBy: ic => ic.Name);
        if (itemCategories.Count == 0)
            throw new NotFoundException("Item categories not found");

        var response = new GetAllItemCategoriesQueryResponse
        {
            ItemCategories = _mapper.Map<List<ItemCategoryDto>>(itemCategories),
            Count = _itemCategoryRepository.Count()
        };

        return response;
    }
}