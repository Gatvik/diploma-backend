using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedItemHisotiresAndItemsName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemHistory_AspNetUsers_UserId",
                table: "ItemHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemHistory_Item_ItemId",
                table: "ItemHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemHistory",
                table: "ItemHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.RenameTable(
                name: "ItemHistory",
                newName: "ItemsHistories");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");

            migrationBuilder.RenameIndex(
                name: "IX_ItemHistory_UserId",
                table: "ItemsHistories",
                newName: "IX_ItemsHistories_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemHistory_ItemId",
                table: "ItemsHistories",
                newName: "IX_ItemsHistories_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemsHistories",
                table: "ItemsHistories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2b9948d2-2236-4c77-b8fc-be51be668d7c", "AQAAAAIAAYagAAAAEDUaITRnvd2MbNpLefaIFKkgCVzlZl8F8J81NGUQewn74oZQYqpFDpJVDr1whyAxZw==" });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsHistories_AspNetUsers_UserId",
                table: "ItemsHistories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsHistories_Items_ItemId",
                table: "ItemsHistories",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsHistories_AspNetUsers_UserId",
                table: "ItemsHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemsHistories_Items_ItemId",
                table: "ItemsHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemsHistories",
                table: "ItemsHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "ItemsHistories",
                newName: "ItemHistory");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");

            migrationBuilder.RenameIndex(
                name: "IX_ItemsHistories_UserId",
                table: "ItemHistory",
                newName: "IX_ItemHistory_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemsHistories_ItemId",
                table: "ItemHistory",
                newName: "IX_ItemHistory_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemHistory",
                table: "ItemHistory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "297105a6-bbad-4e54-b498-0525d04ae087", "AQAAAAIAAYagAAAAEMZG3KNhWUyTGAM9kWBBuiau6Df5XqlhUFRYR2X4C+JeXV89yT85DXcPhyftkCFOiA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemHistory_AspNetUsers_UserId",
                table: "ItemHistory",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemHistory_Item_ItemId",
                table: "ItemHistory",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
