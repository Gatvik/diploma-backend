using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "ShiftTypes");

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    MinimumStockQuantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8e51559c-7ac1-46dd-b8f4-511c238d11e7", "AQAAAAIAAYagAAAAEPL3DuGCw3BoOHpK4kIzeCPZvv/Xbjwjmzh1Ga1emOqa9dfotBOPmxviZ1+6VEaOoA==" });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "Id", "MinimumStockQuantity", "Name", "Quantity" },
                values: new object[,]
                {
                    { new Guid("674c73fc-2a7b-40ba-af56-d6a8a486cb3e"), 80, "Лампочка", 80 },
                    { new Guid("75de4f70-0237-4df5-846f-6e825f946f87"), 500, "Цвях", 500 },
                    { new Guid("8da704f4-af4d-4e1a-b151-74f042572600"), 10, "Комплект постільної білизни", 10 },
                    { new Guid("b702a464-7170-4a7a-b6b7-4ecedda97792"), 30, "Мило", 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.CreateTable(
                name: "ShiftTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ShiftTypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_ShiftTypes_ShiftTypeId",
                        column: x => x.ShiftTypeId,
                        principalTable: "ShiftTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1406b574-6602-4498-b35d-0fbc803ee914", "AQAAAAIAAYagAAAAELvGv52iVPZG+NFbYN2BCYgimuEmh+JbGMiae3AfaIe9KmangxOWA2W4UjnyM3dayw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ShiftTypeId",
                table: "Schedules",
                column: "ShiftTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_UserId",
                table: "Schedules",
                column: "UserId");
        }
    }
}
