using Api.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
    {
        builder.HasData(
            new IdentityUserRole<Guid>
            {
                RoleId = Guid.Parse("cbc43a8e-f7bb-4445-baaf-1add431ffbbf"), // ADMIN
                UserId = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9")
            },
            new IdentityUserRole<Guid>
            {
                RoleId = Guid.Parse("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), // MANAGER
                UserId = Guid.Parse("a9aebd65-e077-4d28-bb62-314428739789")
            },
            new IdentityUserRole<Guid>
            {
                RoleId = Guid.Parse("36f579e8-2f52-473f-91f2-550331d81d04"), // INVENTORYMANAGER
                UserId = Guid.Parse("181eae58-202d-4757-86e2-578df1743d6c")
            },
            new IdentityUserRole<Guid>
            {
                RoleId = Guid.Parse("9beb8da7-4160-4db7-9982-05604a4e51d5"), // HOUSEMAID
                UserId = Guid.Parse("d525eef7-5569-4b54-8b6d-2f796bc9ba9a")
            },
            new IdentityUserRole<Guid>
            {
                RoleId = Guid.Parse("a0f845d1-2680-459d-981a-d40b176c5ca8"), // TECHNICIAN
                UserId = Guid.Parse("217d332c-ef08-4f06-86b3-68df9eb48e73")
            }
        );
    }
}