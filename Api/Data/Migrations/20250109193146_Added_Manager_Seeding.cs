using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class Added_Manager_Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9f7b27fe-c13d-49e4-8ff3-4f0da16b649d", "AQAAAAIAAYagAAAAEOYKglbYwJxT4/p822cD631+A014img7OToiicuarGIFgdA7XOhoCfIpuH052yZwnw==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("a9aebd65-e077-4d28-bb62-314428739789"), 0, "3b60a86f-aa8c-4fe1-9fd8-15beb5ace876", "manager@localhost.com", true, "Manager", "Manager", false, null, "MANAGER@LOCALHOST.COM", "MANAGER@LOCALHOST.COM", "AQAAAAIAAYagAAAAELruwabft5m3daBUO8ZCvorA5QrHPZJbXsIprDX/YGJeIx8rh/oNZDJnePInGIuarw==", null, false, "K2SW2BTS4I5GN4WZYXW3ACQYNRVHX4L6", "male", false, "manager@localhost.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("a9aebd65-e077-4d28-bb62-314428739789") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("a9aebd65-e077-4d28-bb62-314428739789") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9aebd65-e077-4d28-bb62-314428739789"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "113c24c9-ca47-4629-8647-08e2116acf9e", "AQAAAAIAAYagAAAAENvzJHYBBdbNmvOCSvIc5+QyPY20WwAIFN15CRE4MkTMyZi63QaK33ziN8pUoz63bQ==" });
        }
    }
}
