using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesignYourHome.Migrations
{
    public partial class startnew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contractorServices_Contractor_ContractorId",
                table: "contractorServices");

            migrationBuilder.DropForeignKey(
                name: "FK_contractorServices_Service_ServiceId",
                table: "contractorServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contractorServices",
                table: "contractorServices");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "08e65fba-3e54-41c7-bf06-a0a020ee168b", "f6408d62-9c1f-49cc-b72a-a5d34ab15a03" });

            migrationBuilder.RenameTable(
                name: "contractorServices",
                newName: "ContractorServices");

            migrationBuilder.RenameIndex(
                name: "IX_contractorServices_ServiceId",
                table: "ContractorServices",
                newName: "IX_ContractorServices_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_contractorServices_ContractorId",
                table: "ContractorServices",
                newName: "IX_ContractorServices_ContractorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContractorServices",
                table: "ContractorServices",
                column: "ContractorServiceId");

            migrationBuilder.CreateTable(
                name: "Ideaboard",
                columns: table => new
                {
                    IdeaboardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ideaboard", x => x.IdeaboardId);
                    table.ForeignKey(
                        name: "FK_Ideaboard_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdeaImage",
                columns: table => new
                {
                    IdeaImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ImageId = table.Column<int>(nullable: false),
                    IdeaboardId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdeaImage", x => x.IdeaImageId);
                    table.ForeignKey(
                        name: "FK_IdeaImage_Ideaboard_IdeaboardId",
                        column: x => x.IdeaboardId,
                        principalTable: "Ideaboard",
                        principalColumn: "IdeaboardId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdeaImage_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "ImageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1fb18770-b71b-4488-ba3d-cfd6a4c4c33f", 0, "61aca700-5e67-4bc0-ad45-b5f8e65830f7", "admin@admin.com", true, "admin", "admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEF9pscrJvoZDrX6rEwGFGwWENhYcYj9+ZGxIby36fAu1WIV6suKks4AvOIBbyErAkw==", null, false, "78b39635-d8b3-4438-8426-9cc5878315ad", "123 Infinity Way", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "ServiceId", "Name", "ServiceCharge" },
                values: new object[] { 5, "Interior Designer", 7300 });

            migrationBuilder.UpdateData(
                table: "Contractor",
                keyColumn: "ContractorId",
                keyValue: 1,
                column: "UserId",
                value: "1fb18770-b71b-4488-ba3d-cfd6a4c4c33f");

            migrationBuilder.UpdateData(
                table: "Contractor",
                keyColumn: "ContractorId",
                keyValue: 2,
                column: "UserId",
                value: "1fb18770-b71b-4488-ba3d-cfd6a4c4c33f");

            migrationBuilder.UpdateData(
                table: "Contractor",
                keyColumn: "ContractorId",
                keyValue: 3,
                column: "UserId",
                value: "1fb18770-b71b-4488-ba3d-cfd6a4c4c33f");

            migrationBuilder.UpdateData(
                table: "Contractor",
                keyColumn: "ContractorId",
                keyValue: 4,
                column: "UserId",
                value: "1fb18770-b71b-4488-ba3d-cfd6a4c4c33f");

            migrationBuilder.InsertData(
                table: "ContractorServices",
                columns: new[] { "ContractorServiceId", "ContractorId", "ServiceId" },
                values: new object[] { 5, 4, 5 });

            migrationBuilder.UpdateData(
                table: "FixHome",
                keyColumn: "FixHomeId",
                keyValue: 1,
                column: "UserId",
                value: "1fb18770-b71b-4488-ba3d-cfd6a4c4c33f");

            migrationBuilder.UpdateData(
                table: "FixHome",
                keyColumn: "FixHomeId",
                keyValue: 2,
                column: "UserId",
                value: "1fb18770-b71b-4488-ba3d-cfd6a4c4c33f");

            migrationBuilder.UpdateData(
                table: "FixHome",
                keyColumn: "FixHomeId",
                keyValue: 3,
                column: "UserId",
                value: "1fb18770-b71b-4488-ba3d-cfd6a4c4c33f");

            migrationBuilder.InsertData(
                table: "Ideaboard",
                columns: new[] { "IdeaboardId", "Title", "UserId" },
                values: new object[] { 1, "Test", "1fb18770-b71b-4488-ba3d-cfd6a4c4c33f" });

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 1,
                column: "UserId",
                value: "1fb18770-b71b-4488-ba3d-cfd6a4c4c33f");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 2,
                column: "UserId",
                value: "1fb18770-b71b-4488-ba3d-cfd6a4c4c33f");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 3,
                column: "UserId",
                value: "1fb18770-b71b-4488-ba3d-cfd6a4c4c33f");

            migrationBuilder.CreateIndex(
                name: "IX_Ideaboard_UserId",
                table: "Ideaboard",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_IdeaImage_IdeaboardId",
                table: "IdeaImage",
                column: "IdeaboardId");

            migrationBuilder.CreateIndex(
                name: "IX_IdeaImage_ImageId",
                table: "IdeaImage",
                column: "ImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContractorServices_Contractor_ContractorId",
                table: "ContractorServices",
                column: "ContractorId",
                principalTable: "Contractor",
                principalColumn: "ContractorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContractorServices_Service_ServiceId",
                table: "ContractorServices",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContractorServices_Contractor_ContractorId",
                table: "ContractorServices");

            migrationBuilder.DropForeignKey(
                name: "FK_ContractorServices_Service_ServiceId",
                table: "ContractorServices");

            migrationBuilder.DropTable(
                name: "IdeaImage");

            migrationBuilder.DropTable(
                name: "Ideaboard");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContractorServices",
                table: "ContractorServices");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "1fb18770-b71b-4488-ba3d-cfd6a4c4c33f", "61aca700-5e67-4bc0-ad45-b5f8e65830f7" });

            migrationBuilder.DeleteData(
                table: "ContractorServices",
                keyColumn: "ContractorServiceId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 5);

            migrationBuilder.RenameTable(
                name: "ContractorServices",
                newName: "contractorServices");

            migrationBuilder.RenameIndex(
                name: "IX_ContractorServices_ServiceId",
                table: "contractorServices",
                newName: "IX_contractorServices_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ContractorServices_ContractorId",
                table: "contractorServices",
                newName: "IX_contractorServices_ContractorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_contractorServices",
                table: "contractorServices",
                column: "ContractorServiceId");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[] { "08e65fba-3e54-41c7-bf06-a0a020ee168b", 0, "f6408d62-9c1f-49cc-b72a-a5d34ab15a03", "admin@admin.com", true, "admin", "admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAELSjEwa3BZy/GEj2rR5LwD3YFxlRklpECesz2oKCpuo4NruAEKQqBccIV4rYLdgqXA==", null, false, "5f1fcccc-0ab3-45de-9eca-59446c4ca060", "123 Infinity Way", false, "admin@admin.com" });

            migrationBuilder.UpdateData(
                table: "Contractor",
                keyColumn: "ContractorId",
                keyValue: 1,
                column: "UserId",
                value: "08e65fba-3e54-41c7-bf06-a0a020ee168b");

            migrationBuilder.UpdateData(
                table: "Contractor",
                keyColumn: "ContractorId",
                keyValue: 2,
                column: "UserId",
                value: "08e65fba-3e54-41c7-bf06-a0a020ee168b");

            migrationBuilder.UpdateData(
                table: "Contractor",
                keyColumn: "ContractorId",
                keyValue: 3,
                column: "UserId",
                value: "08e65fba-3e54-41c7-bf06-a0a020ee168b");

            migrationBuilder.UpdateData(
                table: "Contractor",
                keyColumn: "ContractorId",
                keyValue: 4,
                column: "UserId",
                value: "08e65fba-3e54-41c7-bf06-a0a020ee168b");

            migrationBuilder.UpdateData(
                table: "FixHome",
                keyColumn: "FixHomeId",
                keyValue: 1,
                column: "UserId",
                value: "08e65fba-3e54-41c7-bf06-a0a020ee168b");

            migrationBuilder.UpdateData(
                table: "FixHome",
                keyColumn: "FixHomeId",
                keyValue: 2,
                column: "UserId",
                value: "08e65fba-3e54-41c7-bf06-a0a020ee168b");

            migrationBuilder.UpdateData(
                table: "FixHome",
                keyColumn: "FixHomeId",
                keyValue: 3,
                column: "UserId",
                value: "08e65fba-3e54-41c7-bf06-a0a020ee168b");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 1,
                column: "UserId",
                value: "08e65fba-3e54-41c7-bf06-a0a020ee168b");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 2,
                column: "UserId",
                value: "08e65fba-3e54-41c7-bf06-a0a020ee168b");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 3,
                column: "UserId",
                value: "08e65fba-3e54-41c7-bf06-a0a020ee168b");

            migrationBuilder.AddForeignKey(
                name: "FK_contractorServices_Contractor_ContractorId",
                table: "contractorServices",
                column: "ContractorId",
                principalTable: "Contractor",
                principalColumn: "ContractorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_contractorServices_Service_ServiceId",
                table: "contractorServices",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "ServiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
