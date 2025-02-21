using Api.Application.Features.ItemCategory.Common;
using Api.Domain;
using AutoMapper;

namespace Api.Application.MappingProfiles;

public class ItemCategoryMappingProfile : Profile
{
    public ItemCategoryMappingProfile()
    {
        CreateMap<ItemCategory, ItemCategoryDto>();
    }
}