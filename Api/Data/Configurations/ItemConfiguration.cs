using Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Configurations;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        builder.HasData(
            new Item
            {
                Id = Guid.Parse("8da704f4-af4d-4e1a-b151-74f042572600"),
                Name = "Bedding set",
                Quantity = 10,
                MinimumStockQuantity = 10
            },
            new Item
            {
                Id = Guid.Parse("b702a464-7170-4a7a-b6b7-4ecedda97792"),
                Name = "Soap",
                Quantity = 30,
                MinimumStockQuantity = 30
            },
            new Item
            {
                Id = Guid.Parse("75de4f70-0237-4df5-846f-6e825f946f87"),
                Name = "Nail",
                Quantity = 500,
                MinimumStockQuantity = 500
            },
            new Item
            {
                Id = Guid.Parse("674c73fc-2a7b-40ba-af56-d6a8a486cb3e"),
                Name = "Light bulb",
                Quantity = 80,
                MinimumStockQuantity = 80
            }
        );
    }
}