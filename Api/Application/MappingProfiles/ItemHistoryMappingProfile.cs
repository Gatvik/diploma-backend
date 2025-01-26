using Api.Application.Features.ItemHistory.Common;
using Api.Domain;
using AutoMapper;

namespace Api.Application.MappingProfiles;

public class ItemHistoryMappingProfile : Profile
{
    public ItemHistoryMappingProfile()
    {
        CreateMap<ItemHistory, ItemHistoryDto>();
    }
}