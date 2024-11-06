using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class ItemHistoryAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false),
                    PerformedAction = table.Column<string>(type: "text", nullable: false),
                    DateOfAction = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemHistory_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemHistory_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "297105a6-bbad-4e54-b498-0525d04ae087", "AQAAAAIAAYagAAAAEMZG3KNhWUyTGAM9kWBBuiau6Df5XqlhUFRYR2X4C+JeXV89yT85DXcPhyftkCFOiA==" });

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "Id",
                keyValue: new Guid("674c73fc-2a7b-40ba-af56-d6a8a486cb3e"),
                column: "Name",
                value: "Light bulb");

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "Id",
                keyValue: new Guid("75de4f70-0237-4df5-846f-6e825f946f87"),
                column: "Name",
                value: "Nail");

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "Id",
                keyValue: new Guid("8da704f4-af4d-4e1a-b151-74f042572600"),
                column: "Name",
                value: "Bedding set");

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "Id",
                keyValue: new Guid("b702a464-7170-4a7a-b6b7-4ecedda97792"),
                column: "Name",
                value: "Soap");

            migrationBuilder.CreateIndex(
                name: "IX_ItemHistory_ItemId",
                table: "ItemHistory",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemHistory_UserId",
                table: "ItemHistory",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemHistory");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8e51559c-7ac1-46dd-b8f4-511c238d11e7", "AQAAAAIAAYagAAAAEPL3DuGCw3BoOHpK4kIzeCPZvv/Xbjwjmzh1Ga1emOqa9dfotBOPmxviZ1+6VEaOoA==" });

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "Id",
                keyValue: new Guid("674c73fc-2a7b-40ba-af56-d6a8a486cb3e"),
                column: "Name",
                value: "Лампочка");

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "Id",
                keyValue: new Guid("75de4f70-0237-4df5-846f-6e825f946f87"),
                column: "Name",
                value: "Цвях");

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "Id",
                keyValue: new Guid("8da704f4-af4d-4e1a-b151-74f042572600"),
                column: "Name",
                value: "Комплект постільної білизни");

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "Id",
                keyValue: new Guid("b702a464-7170-4a7a-b6b7-4ecedda97792"),
                column: "Name",
                value: "Мило");
        }
    }
}
