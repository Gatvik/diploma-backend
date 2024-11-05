using Api.Application.Features.Item.Commands.Create;
using Api.Application.Features.Item.Commands.Update;
using Api.Application.Features.Item.Shared;
using Api.Domain;
using AutoMapper;

namespace Api.Application.MappingProfiles;

public class ItemMappingProfile : Profile
{
    public ItemMappingProfile()
    {
        CreateMap<Item, ItemDto>();
        CreateMap<CreateItemCommand, Item>();
        CreateMap<UpdateItemCommand, Item>();
    }
}