using Api.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        var hasher = new PasswordHasher<User>();
        builder.HasData(
            new User
            {
                Id = Guid.Parse("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                Email = "admin@localhost.com",
                NormalizedEmail = "ADMIN@LOCALHOST.COM",
                UserName = "admin@localhost.com",
                NormalizedUserName = "ADMIN@LOCALHOST.COM",
                PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                SecurityStamp = "K2SW2BTS4I5GN4WZYXW3ACQYNRVHX4L6",
                EmailConfirmed = true,
                FirstName = "Admin",
                LastName = "Admin",
                Sex = "male"
            },
            new User
            {
                Id = Guid.Parse("a9aebd65-e077-4d28-bb62-314428739789"),
                Email = "manager@localhost.com",
                NormalizedEmail = "MANAGER@LOCALHOST.COM",
                UserName = "manager@localhost.com",
                NormalizedUserName = "MANAGER@LOCALHOST.COM",
                PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                SecurityStamp = "K2SW2BTS4I5GN4WZYXW3ACQYNRVHX4L6",
                EmailConfirmed = true,
                FirstName = "Manager",
                LastName = "Manager",
                Sex = "male"
            },
            new User
            {
                Id = Guid.Parse("181eae58-202d-4757-86e2-578df1743d6c"),
                Email = "inventorymanager@localhost.com",
                NormalizedEmail = "INVENTORYMANAGER@LOCALHOST.COM",
                UserName = "inventorymanager@localhost.com",
                NormalizedUserName = "INVENTORYMANAGER@LOCALHOST.COM",
                PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                SecurityStamp = "K2SW2BTS4I5GN4WZYXW3ACQYNRVHX4L6",
                EmailConfirmed = true,
                FirstName = "InventoryManager",
                LastName = "InventoryManager",
                Sex = "male"
            },
            new User
            {
                Id = Guid.Parse("d525eef7-5569-4b54-8b6d-2f796bc9ba9a"),
                Email = "housemaid@localhost.com",
                NormalizedEmail = "HOUSEMAID@LOCALHOST.COM",
                UserName = "housemaid@localhost.com",
                NormalizedUserName = "HOUSEMAID@LOCALHOST.COM",
                PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                SecurityStamp = "K2SW2BTS4I5GN4WZYXW3ACQYNRVHX4L6",
                EmailConfirmed = true,
                FirstName = "Housemaid",
                LastName = "Housemaid",
                Sex = "female"
            },
            new User
            {
                Id = Guid.Parse("217d332c-ef08-4f06-86b3-68df9eb48e73"),
                Email = "technician@localhost.com",
                NormalizedEmail = "TECHNICIAN@LOCALHOST.COM",
                UserName = "technician@localhost.com",
                NormalizedUserName = "TECHNICIAN@LOCALHOST.COM",
                PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                SecurityStamp = "K2SW2BTS4I5GN4WZYXW3ACQYNRVHX4L6",
                EmailConfirmed = true,
                FirstName = "Technician",
                LastName = "Technician",
                Sex = "male"
            }
        );
    }
}