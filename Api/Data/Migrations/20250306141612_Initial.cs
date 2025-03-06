using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Sex = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssignmentToUserStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentToUserStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ItemCategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    MinimumStockQuantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_ItemCategories_ItemCategoryId",
                        column: x => x.ItemCategoryId,
                        principalTable: "ItemCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssignmentsToUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Details = table.Column<string>(type: "text", nullable: false),
                    AssignmentToUserStatusId = table.Column<Guid>(type: "uuid", nullable: false),
                    AssignmentId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentsToUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignmentsToUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignmentsToUsers_AssignmentToUserStatuses_AssignmentToUse~",
                        column: x => x.AssignmentToUserStatusId,
                        principalTable: "AssignmentToUserStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignmentsToUsers_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemsHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<int>(type: "integer", nullable: false),
                    PerformedAction = table.Column<string>(type: "text", nullable: false),
                    DateOfAction = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemsHistories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ItemsHistories_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("36f579e8-2f52-473f-91f2-550331d81d04"), null, "InventoryManager", "INVENTORYMANAGER" },
                    { new Guid("9beb8da7-4160-4db7-9982-05604a4e51d5"), null, "Housemaid", "HOUSEMAID" },
                    { new Guid("a0f845d1-2680-459d-981a-d40b176c5ca8"), null, "Technician", "TECHNICIAN" },
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), null, "Manager", "MANAGER" },
                    { new Guid("cbc43a8e-f7bb-4445-baaf-1add431ffbbf"), null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("181eae58-202d-4757-86e2-578df1743d6c"), 0, "521abc88-1ef1-4321-a9d7-b4ad2f90c9e1", "inventorymanager@localhost.com", true, "InventoryManager", "InventoryManager", false, null, "INVENTORYMANAGER@LOCALHOST.COM", "INVENTORYMANAGER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEOBzvzQitS3oeUfs6onaRBwN0W7XKGkp9g7eeqAh2OV1pHsGL8fXUONirpVDLiw80w==", null, false, "K2SW2BTS4I5GN4WZYXW3ACQYNRVHX4L6", "male", false, "inventorymanager@localhost.com" },
                    { new Guid("217d332c-ef08-4f06-86b3-68df9eb48e73"), 0, "f1239b90-0ec4-4b9e-8331-322edc7eaf12", "technician@localhost.com", true, "Technician", "Technician", false, null, "TECHNICIAN@LOCALHOST.COM", "TECHNICIAN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEOBzvzQitS3oeUfs6onaRBwN0W7XKGkp9g7eeqAh2OV1pHsGL8fXUONirpVDLiw80w==", null, false, "K2SW2BTS4I5GN4WZYXW3ACQYNRVHX4L6", "male", false, "technician@localhost.com" },
                    { new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), 0, "d743cd79-de33-4733-b51d-580caa50f40a", "admin@localhost.com", true, "Admin", "Admin", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAEOBzvzQitS3oeUfs6onaRBwN0W7XKGkp9g7eeqAh2OV1pHsGL8fXUONirpVDLiw80w==", null, false, "K2SW2BTS4I5GN4WZYXW3ACQYNRVHX4L6", "male", false, "admin@localhost.com" },
                    { new Guid("a9aebd65-e077-4d28-bb62-314428739789"), 0, "80af2796-87a3-47ca-8f6d-d6318ae6a7d0", "manager@localhost.com", true, "Manager", "Manager", false, null, "MANAGER@LOCALHOST.COM", "MANAGER@LOCALHOST.COM", "AQAAAAIAAYagAAAAEOBzvzQitS3oeUfs6onaRBwN0W7XKGkp9g7eeqAh2OV1pHsGL8fXUONirpVDLiw80w==", null, false, "K2SW2BTS4I5GN4WZYXW3ACQYNRVHX4L6", "male", false, "manager@localhost.com" },
                    { new Guid("d525eef7-5569-4b54-8b6d-2f796bc9ba9a"), 0, "a6212ed6-94cb-4ecf-93f8-8219d0a9927f", "housemaid@localhost.com", true, "Housemaid", "Housemaid", false, null, "HOUSEMAID@LOCALHOST.COM", "HOUSEMAID@LOCALHOST.COM", "AQAAAAIAAYagAAAAEOBzvzQitS3oeUfs6onaRBwN0W7XKGkp9g7eeqAh2OV1pHsGL8fXUONirpVDLiw80w==", null, false, "K2SW2BTS4I5GN4WZYXW3ACQYNRVHX4L6", "female", false, "housemaid@localhost.com" }
                });

            migrationBuilder.InsertData(
                table: "AssignmentToUserStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("05f8bba5-01df-476b-9886-8b18eb95efef"), "In Progress" },
                    { new Guid("2bfa63c2-77e9-44eb-a36d-7fa181e64cf0"), "Completed" },
                    { new Guid("3022c20b-6201-4569-ba95-1a5eb8b7be83"), "Not Accepted" },
                    { new Guid("c6f0b461-e6ae-42fd-b13b-0e52c67c48e1"), "Approved" },
                    { new Guid("cf20d3b5-226e-4716-a299-dc25f98740c3"), "Rejected" }
                });

            migrationBuilder.InsertData(
                table: "ItemCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("37be3767-b73f-4abd-94db-e47a719e7dd4"), "Repair" },
                    { new Guid("8da704f4-af4d-4e1a-b151-74f042572600"), "Bed" },
                    { new Guid("db8c54ca-7da5-4e51-9490-861e44c86079"), "Bathroom" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("36f579e8-2f52-473f-91f2-550331d81d04"), new Guid("181eae58-202d-4757-86e2-578df1743d6c") },
                    { new Guid("a0f845d1-2680-459d-981a-d40b176c5ca8"), new Guid("217d332c-ef08-4f06-86b3-68df9eb48e73") },
                    { new Guid("cbc43a8e-f7bb-4445-baaf-1add431ffbbf"), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9") },
                    { new Guid("cac43a6e-f7bb-4448-baaf-1add431ccbbf"), new Guid("a9aebd65-e077-4d28-bb62-314428739789") },
                    { new Guid("9beb8da7-4160-4db7-9982-05604a4e51d5"), new Guid("d525eef7-5569-4b54-8b6d-2f796bc9ba9a") }
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "Name", "RoleId" },
                values: new object[,]
                {
                    { new Guid("58302ce8-d000-4301-b24b-52cd5ded95a2"), "Replace light bulb", new Guid("a0f845d1-2680-459d-981a-d40b176c5ca8") },
                    { new Guid("c8837679-cb17-41a3-93b0-c7d797a61a76"), "Clear room", new Guid("9beb8da7-4160-4db7-9982-05604a4e51d5") }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "ItemCategoryId", "MinimumStockQuantity", "Name", "Quantity" },
                values: new object[,]
                {
                    { new Guid("674c73fc-2a7b-40ba-af56-d6a8a486cb3e"), new Guid("37be3767-b73f-4abd-94db-e47a719e7dd4"), 80, "Light bulb", 80 },
                    { new Guid("75de4f70-0237-4df5-846f-6e825f946f87"), new Guid("37be3767-b73f-4abd-94db-e47a719e7dd4"), 500, "Nail", 500 },
                    { new Guid("8da704f4-af4d-4e1a-b151-74f042572600"), new Guid("8da704f4-af4d-4e1a-b151-74f042572600"), 10, "Bedding set", 10 },
                    { new Guid("b702a464-7170-4a7a-b6b7-4ecedda97792"), new Guid("db8c54ca-7da5-4e51-9490-861e44c86079"), 30, "Soap", 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_RoleId",
                table: "Assignments",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentsToUsers_AssignmentId",
                table: "AssignmentsToUsers",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentsToUsers_AssignmentToUserStatusId",
                table: "AssignmentsToUsers",
                column: "AssignmentToUserStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentsToUsers_UserId",
                table: "AssignmentsToUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemCategoryId",
                table: "Items",
                column: "ItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsHistories_ItemId",
                table: "ItemsHistories",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsHistories_UserId",
                table: "ItemsHistories",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AssignmentsToUsers");

            migrationBuilder.DropTable(
                name: "ItemsHistories");

            migrationBuilder.DropTable(
                name: "AssignmentToUserStatuses");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "ItemCategories");
        }
    }
}
