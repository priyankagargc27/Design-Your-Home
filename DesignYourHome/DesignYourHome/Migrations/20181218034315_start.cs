using Microsoft.EntityFrameworkCore.Migrations;

namespace DesignYourHome.Migrations
{
    public partial class start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "1fb18770-b71b-4488-ba3d-cfd6a4c4c33f", "61aca700-5e67-4bc0-ad45-b5f8e65830f7" });

            migrationBuilder.DeleteData(
                table: "ContractorServices",
                keyColumn: "ContractorServiceId",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dc31bda2-96b1-4c2c-ad23-a38d23df7cf3", 0, "dbad5dfb-956e-4bff-b1f9-a994cf56a4a8", "admin@admin.com", true, "admin", "admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEBuEyJgpAcxFZL7BR3wWdfAedAKstdOnBHS4G2C2DxYOKSaRjswbutzWvcclE+fVlA==", null, false, "6c98d0dd-b5d5-4b3d-8d26-aa667a8c0b33", "123 Infinity Way", false, "admin@admin.com" });

            migrationBuilder.UpdateData(
                table: "Contractor",
                keyColumn: "ContractorId",
                keyValue: 1,
                column: "UserId",
                value: "dc31bda2-96b1-4c2c-ad23-a38d23df7cf3");

            migrationBuilder.UpdateData(
                table: "Contractor",
                keyColumn: "ContractorId",
                keyValue: 2,
                column: "UserId",
                value: "dc31bda2-96b1-4c2c-ad23-a38d23df7cf3");

            migrationBuilder.UpdateData(
                table: "Contractor",
                keyColumn: "ContractorId",
                keyValue: 3,
                column: "UserId",
                value: "dc31bda2-96b1-4c2c-ad23-a38d23df7cf3");

            migrationBuilder.UpdateData(
                table: "Contractor",
                keyColumn: "ContractorId",
                keyValue: 4,
                column: "UserId",
                value: "dc31bda2-96b1-4c2c-ad23-a38d23df7cf3");

            migrationBuilder.UpdateData(
                table: "FixHome",
                keyColumn: "FixHomeId",
                keyValue: 1,
                column: "UserId",
                value: "dc31bda2-96b1-4c2c-ad23-a38d23df7cf3");

            migrationBuilder.UpdateData(
                table: "FixHome",
                keyColumn: "FixHomeId",
                keyValue: 2,
                column: "UserId",
                value: "dc31bda2-96b1-4c2c-ad23-a38d23df7cf3");

            migrationBuilder.UpdateData(
                table: "FixHome",
                keyColumn: "FixHomeId",
                keyValue: 3,
                column: "UserId",
                value: "dc31bda2-96b1-4c2c-ad23-a38d23df7cf3");

            migrationBuilder.UpdateData(
                table: "Ideaboard",
                keyColumn: "IdeaboardId",
                keyValue: 1,
                column: "UserId",
                value: "dc31bda2-96b1-4c2c-ad23-a38d23df7cf3");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 1,
                column: "UserId",
                value: "dc31bda2-96b1-4c2c-ad23-a38d23df7cf3");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 2,
                column: "UserId",
                value: "dc31bda2-96b1-4c2c-ad23-a38d23df7cf3");

            migrationBuilder.UpdateData(
                table: "Room",
                keyColumn: "RoomId",
                keyValue: 3,
                column: "UserId",
                value: "dc31bda2-96b1-4c2c-ad23-a38d23df7cf3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "dc31bda2-96b1-4c2c-ad23-a38d23df7cf3", "dbad5dfb-956e-4bff-b1f9-a994cf56a4a8" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StreetAddress", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1fb18770-b71b-4488-ba3d-cfd6a4c4c33f", 0, "61aca700-5e67-4bc0-ad45-b5f8e65830f7", "admin@admin.com", true, "admin", "admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEF9pscrJvoZDrX6rEwGFGwWENhYcYj9+ZGxIby36fAu1WIV6suKks4AvOIBbyErAkw==", null, false, "78b39635-d8b3-4438-8426-9cc5878315ad", "123 Infinity Way", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "ContractorServices",
                columns: new[] { "ContractorServiceId", "ContractorId", "ServiceId" },
                values: new object[] { 5, 4, 5 });

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

            migrationBuilder.UpdateData(
                table: "Ideaboard",
                keyColumn: "IdeaboardId",
                keyValue: 1,
                column: "UserId",
                value: "1fb18770-b71b-4488-ba3d-cfd6a4c4c33f");

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
        }
    }
}
