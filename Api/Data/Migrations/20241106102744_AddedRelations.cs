using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsHistories_AspNetUsers_UserId",
                table: "ItemsHistories");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7797fee0-57d9-406c-9954-6bf866924642", "AQAAAAIAAYagAAAAEEsoa1M6WHvpzyxlTuLl8EpZDLcPWjjZud3xV+BNdhb3wCP1WbzJehpMNcgJv05ABg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsHistories_AspNetUsers_UserId",
                table: "ItemsHistories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsHistories_AspNetUsers_UserId",
                table: "ItemsHistories");

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
        }
    }
}
