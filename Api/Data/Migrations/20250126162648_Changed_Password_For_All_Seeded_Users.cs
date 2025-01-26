using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class Changed_Password_For_All_Seeded_Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("181eae58-202d-4757-86e2-578df1743d6c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "443afa27-4559-4729-90fe-864d79113fef", "AQAAAAIAAYagAAAAEOBzvzQitS3oeUfs6onaRBwN0W7XKGkp9g7eeqAh2OV1pHsGL8fXUONirpVDLiw80w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("217d332c-ef08-4f06-86b3-68df9eb48e73"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "47182375-ef69-4b12-be8d-09dacae70737", "AQAAAAIAAYagAAAAEOBzvzQitS3oeUfs6onaRBwN0W7XKGkp9g7eeqAh2OV1pHsGL8fXUONirpVDLiw80w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                column: "ConcurrencyStamp",
                value: "e873506c-e94a-4559-8e7e-0e1c464b2abe");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9aebd65-e077-4d28-bb62-314428739789"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6f0bb5af-278b-46e5-8c3d-c4449c7b29f4", "AQAAAAIAAYagAAAAEOBzvzQitS3oeUfs6onaRBwN0W7XKGkp9g7eeqAh2OV1pHsGL8fXUONirpVDLiw80w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d525eef7-5569-4b54-8b6d-2f796bc9ba9a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9388fdb0-f546-4589-929f-0eeefbfed1c3", "AQAAAAIAAYagAAAAEOBzvzQitS3oeUfs6onaRBwN0W7XKGkp9g7eeqAh2OV1pHsGL8fXUONirpVDLiw80w==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("181eae58-202d-4757-86e2-578df1743d6c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9914c567-56ac-4f95-8fb9-d073e0900fa6", "AQAAAAIAAYagAAAAEARaVSmblpqlIstjtXVYPE6K+WUymjphHzTvusY/q/wLrLI4hICBTufRKeLcwjEz9A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("217d332c-ef08-4f06-86b3-68df9eb48e73"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "99727b51-d72f-44a6-ae5b-972299cf9064", "AQAAAAIAAYagAAAAEOtU23tYfQnDk0st/oDxEFC9RkDnw6pOhbqSj+zK7Bw0TI5v+Q6IfkC1ZjVHIVWA7w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"),
                column: "ConcurrencyStamp",
                value: "ae77368a-06c3-4f69-95b3-c78911b362ed");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a9aebd65-e077-4d28-bb62-314428739789"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "548f2949-abaa-4643-96f9-d0fe9a7f4b23", "AQAAAAIAAYagAAAAEF0bPZ+h4O00pez8Gx8sD0rKXIJHuECsIQPX9GD9XgB41xOf/idfRBY1/NphMOMO+A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d525eef7-5569-4b54-8b6d-2f796bc9ba9a"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8abcecc7-8c1c-4820-875c-009891989185", "AQAAAAIAAYagAAAAEFKIbpxFl9/WgyJ8wM/3EjIr8iSewPXg7oitXcwqjDlYizG2p3PdidieMLSnpnV54w==" });
        }
    }
}
