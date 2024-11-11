using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class MovedDescriptionField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Assignments");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "AssignmentsToUsers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ac0833d5-6331-4b2c-ac6c-7b711c9686f0", "AQAAAAIAAYagAAAAECPsRsDnl+6cqyz9MITqTD02oRgIzahy3usPxuYh0pfaCWGlv71oKCSoUgzta5wICg==" });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "Name", "RoleId" },
                values: new object[,]
                {
                    { new Guid("58302ce8-d000-4301-b24b-52cd5ded95a2"), "Replace light bulb", new Guid("a0f845d1-2680-459d-981a-d40b176c5ca8") },
                    { new Guid("c8837679-cb17-41a3-93b0-c7d797a61a76"), "Clear room", new Guid("9beb8da7-4160-4db7-9982-05604a4e51d5") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("58302ce8-d000-4301-b24b-52cd5ded95a2"));

            migrationBuilder.DeleteData(
                table: "Assignments",
                keyColumn: "Id",
                keyValue: new Guid("c8837679-cb17-41a3-93b0-c7d797a61a76"));

            migrationBuilder.DropColumn(
                name: "Details",
                table: "AssignmentsToUsers");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Assignments",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "439670ca-b555-44fd-8d60-81ea41f1cd93", "AQAAAAIAAYagAAAAEPcyDGeb7mie7pdsQbTWs5hI9gZocOEJvtEvVZH2cVX9A5FBsSu4LKySkk34fJxgLg==" });
        }
    }
}
