using Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Configurations;

public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
{
    public void Configure(EntityTypeBuilder<Assignment> builder)
    {
        builder.HasData(
            new Assignment
            {
                Id = Guid.Parse("c8837679-cb17-41a3-93b0-c7d797a61a76"),
                Name = "Clear room",
                RoleId = Guid.Parse("9beb8da7-4160-4db7-9982-05604a4e51d5"), // Housemaid
            },
            new Assignment
            {
                Id = Guid.Parse("58302ce8-d000-4301-b24b-52cd5ded95a2"),
                Name = "Replace light bulb",
                RoleId = Guid.Parse("a0f845d1-2680-459d-981a-d40b176c5ca8"), // Technician
            }
            );
    }
}