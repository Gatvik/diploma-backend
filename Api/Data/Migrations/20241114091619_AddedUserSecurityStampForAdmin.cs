using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserSecurityStampForAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "800e122c-3944-4ac4-a116-eb599200db29", "AQAAAAIAAYagAAAAEGm2p9LpmxgpqO9eaAFi6ZB9DOD/Z0dN99krNVQDNHAzmSUF5UfH4iXxfEuJcPtksw==", "K2SW2BTS4I5GN4WZYXW3ACQYNRVHX4L6" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3375f1b4-b0fe-4ada-ac4c-9d7a80a21ee7", "AQAAAAIAAYagAAAAEMVTzi5ZgxYcgrD+DkhfhfSZ+FwXP2M1oBfhFBwj1M7wh2vLhf0DRqXDF5jw08zeTQ==", null });
        }
    }
}
