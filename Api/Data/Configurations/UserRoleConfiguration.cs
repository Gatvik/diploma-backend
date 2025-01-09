﻿using Api.Data.Models;
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
            }
        );
    }
}