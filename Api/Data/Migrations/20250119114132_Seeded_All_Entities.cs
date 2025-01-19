using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seeded_All_Entities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ae77368a-06c3-4f69-95b3-c78911b362ed", "AQAAAAIAAYagAAAAEOBzvzQitS3oeUfs6onaRBwN0W7XKGkp9g7eeqAh2OV1pHsGL8fXUONirpVDLiw80w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9aebd65-e077-4d28-bb62-314428739789"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "548f2949-abaa-4643-96f9-d0fe9a7f4b23", "AQAAAAIAAYagAAAAEF0bPZ+h4O00pez8Gx8sD0rKXIJHuECsIQPX9GD9XgB41xOf/idfRBY1/NphMOMO+A==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("181eae58-202d-4757-86e2-578df1743d6c"), 0, "9914c567-56ac-4f95-8fb9-d073e0900fa6", "inventorymanager@localhost.com", true, "InventoryManager", "InventoryManager", false, null, "INVENTORYMANAGER@LOCALHOST.COM", "INVENTORYMANAGER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEARaVSmblpqlIstjtXVYPE6K+WUymjphHzTvusY/q/wLrLI4hICBTufRKeLcwjEz9A==", null, false, "K2SW2BTS4I5GN4WZYXW3ACQYNRVHX4L6", "male", false, "inventorymanager@localhost.com" },
                    { new Guid("217d332c-ef08-4f06-86b3-68df9eb48e73"), 0, "99727b51-d72f-44a6-ae5b-972299cf9064", "technician@localhost.com", true, "Technician", "Technician", false, null, "TECHNICIAN@LOCALHOST.COM", "TECHNICIAN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEOtU23tYfQnDk0st/oDxEFC9RkDnw6pOhbqSj+zK7Bw0TI5v+Q6IfkC1ZjVHIVWA7w==", null, false, "K2SW2BTS4I5GN4WZYXW3ACQYNRVHX4L6", "male", false, "technician@localhost.com" },
                    { new Guid("d525eef7-5569-4b54-8b6d-2f796bc9ba9a"), 0, "8abcecc7-8c1c-4820-875c-009891989185", "housemaid@localhost.com", true, "Housemaid", "Housemaid", false, null, "HOUSEMAID@LOCALHOST.COM", "HOUSEMAID@LOCALHOST.COM", "AQAAAAIAAYagAAAAEFKIbpxFl9/WgyJ8wM/3EjIr8iSewPXg7oitXcwqjDlYizG2p3PdidieMLSnpnV54w==", null, false, "K2SW2BTS4I5GN4WZYXW3ACQYNRVHX4L6", "female", false, "housemaid@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("36f579e8-2f52-473f-91f2-550331d81d04"), new Guid("181eae58-202d-4757-86e2-578df1743d6c") },
                    { new Guid("a0f845d1-2680-459d-981a-d40b176c5ca8"), new Guid("217d332c-ef08-4f06-86b3-68df9eb48e73") },
                    { new Guid("9beb8da7-4160-4db7-9982-05604a4e51d5"), new Guid("d525eef7-5569-4b54-8b6d-2f796bc9ba9a") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("36f579e8-2f52-473f-91f2-550331d81d04"), new Guid("181eae58-202d-4757-86e2-578df1743d6c") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a0f845d1-2680-459d-981a-d40b176c5ca8"), new Guid("217d332c-ef08-4f06-86b3-68df9eb48e73") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9beb8da7-4160-4db7-9982-05604a4e51d5"), new Guid("d525eef7-5569-4b54-8b6d-2f796bc9ba9a") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("181eae58-202d-4757-86e2-578df1743d6c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("217d332c-ef08-4f06-86b3-68df9eb48e73"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d525eef7-5569-4b54-8b6d-2f796bc9ba9a"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9f7b27fe-c13d-49e4-8ff3-4f0da16b649d", "AQAAAAIAAYagAAAAEOYKglbYwJxT4/p822cD631+A014img7OToiicuarGIFgdA7XOhoCfIpuH052yZwnw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9aebd65-e077-4d28-bb62-314428739789"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3b60a86f-aa8c-4fe1-9fd8-15beb5ace876", "AQAAAAIAAYagAAAAELruwabft5m3daBUO8ZCvorA5QrHPZJbXsIprDX/YGJeIx8rh/oNZDJnePInGIuarw==" });
        }
    }
}
