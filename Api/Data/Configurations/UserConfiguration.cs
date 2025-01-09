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
            }
        );
    }
}