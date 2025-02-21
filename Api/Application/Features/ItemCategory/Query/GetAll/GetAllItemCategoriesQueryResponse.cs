using Api.Application.Features.ItemCategory.Common;

namespace Api.Application.Features.ItemCategory.Query.GetAll;

public class GetAllItemCategoriesQueryResponse
{
    public List<ItemCategoryDto> ItemCategories { get; set; }
    public int Count { get; set; }
}