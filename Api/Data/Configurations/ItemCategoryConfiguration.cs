using Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Configurations;

public class ItemCategoryConfiguration : IEntityTypeConfiguration<ItemCategory>
{
    public void Configure(EntityTypeBuilder<ItemCategory> builder)
    {
        builder.HasData(
            new ItemCategory
            {
                Id = Guid.Parse("8da704f4-af4d-4e1a-b151-74f042572600"),
                Name = "Bed",
            },
            new ItemCategory
            {
                Id = Guid.Parse("db8c54ca-7da5-4e51-9490-861e44c86079"),
                Name = "Bathroom",
            },
            new ItemCategory
            {
                Id = Guid.Parse("37be3767-b73f-4abd-94db-e47a719e7dd4"),
                Name = "Repair",
            });
    }
}