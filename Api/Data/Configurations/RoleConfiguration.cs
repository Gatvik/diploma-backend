using Api.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<AppRole>
{
    public void Configure(EntityTypeBuilder<AppRole> builder)
    {
        builder.HasData(
            new AppRole
            {
                Id = Guid.Parse("cac43a6e-f7bb-4448-baaf-1add431ccbbf"),
                Name = "Manager",
                NormalizedName = "MANAGER"
            },
            new AppRole
            {
                Id = Guid.Parse("cbc43a8e-f7bb-4445-baaf-1add431ffbbf"),
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            },
            new AppRole
            {
                Id = Guid.Parse("a0f845d1-2680-459d-981a-d40b176c5ca8"),
                Name = "Technician",
                NormalizedName = "TECHNICIAN"
            },
            new AppRole
            {
                Id = Guid.Parse("9beb8da7-4160-4db7-9982-05604a4e51d5"),
                Name = "Housemaid",
                NormalizedName = "HOUSEMAID"
            },
            new AppRole
            {
                Id = Guid.Parse("36f579e8-2f52-473f-91f2-550331d81d04"),
                Name = "InventoryManager",
                NormalizedName = "INVENTORYMANAGER"
            }
        );
    }
}