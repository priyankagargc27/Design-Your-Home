using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesignYourHome.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    StreetAddress = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    ServiceCharge = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Style",
                columns: table => new
                {
                    StyleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    isSelected = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Style", x => x.StyleId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contractor",
                columns: table => new
                {
                    ContractorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Website = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractor", x => x.ContractorId);
                    table.ForeignKey(
                        name: "FK_Contractor_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoomId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Design = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Room_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContractorServices",
                columns: table => new
                {
                    ContractorServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContractorId = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractorServices", x => x.ContractorServiceId);
                    table.ForeignKey(
                        name: "FK_ContractorServices_Contractor_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractor",
                        principalColumn: "ContractorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractorServices_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FixHome",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    FixHomeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContractorId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FixHome", x => x.FixHomeId);
                    table.ForeignKey(
                        name: "FK_FixHome_Contractor_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractor",
                        principalColumn: "ContractorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FixHome_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FixHome_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    ImageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Source = table.Column<string>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    StyleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Image_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Image_Style_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Style",
                        principalColumn: "StyleId",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
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
                values: new object[] { "0da28dc6-ae72-434e-9e4f-1abd2bd76d01", 0, "37f06fa3-a070-4492-ae4b-38039ff877cf", "admin@admin.com", true, "admin", "admin", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEIBmQlAyMGELxMSAtCwq3OachW0jBAVsGpN4EiUoBQF2BDvfloTff6VJqz8dUnQ+TQ==", null, false, "95de6189-1e60-488d-9276-e19b3c626f0f", "123 Infinity Way", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "ServiceId", "Name", "ServiceCharge" },
                values: new object[,]
                {
                    { 1, "Flooring", 2500 },
                    { 2, "Painter", 1500 },
                    { 3, "Electrician", 4500 },
                    { 4, "Plumber", 4500 },
                    { 5, "Interior Designer", 7300 }
                });

            migrationBuilder.InsertData(
                table: "Style",
                columns: new[] { "StyleId", "Name", "isSelected" },
                values: new object[,]
                {
                    { 1, "Contemporary", false },
                    { 2, "Modern", false },
                    { 3, "Beach Style", false },
                    { 4, "Rustic", false },
                    { 5, "Farmhouse", false }
                });

            migrationBuilder.InsertData(
                table: "Contractor",
                columns: new[] { "ContractorId", "City", "CompanyName", "Name", "PhoneNumber", "State", "UserId", "Website" },
                values: new object[,]
                {
                    { 1, "Franklin", "Fixhome", "John Doe", "615-847-3636", "Tenneessee", "0da28dc6-ae72-434e-9e4f-1abd2bd76d01", "www.fixhome.com" },
                    { 2, "Spring Hill", "Pulte", "Will Healy", "625-337-3326", "Tenneessee", "0da28dc6-ae72-434e-9e4f-1abd2bd76d01", "www.Pulte.com" },
                    { 3, "Brentwood ", "Ryan", "Adam Sandler", "625-567-3326", "Tenneessee", "0da28dc6-ae72-434e-9e4f-1abd2bd76d01", "www.Ryan.com" },
                    { 4, "Nashville ", "SaraRayInteriorDesign", "Sara Ray", "625-567-3426", "Tenneessee", "0da28dc6-ae72-434e-9e4f-1abd2bd76d01", "www.SaraRayInteriorDesign.com" }
                });

            migrationBuilder.InsertData(
                table: "Ideaboard",
                columns: new[] { "IdeaboardId", "Title", "UserId" },
                values: new object[] { 1, "Test", "0da28dc6-ae72-434e-9e4f-1abd2bd76d01" });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "RoomId", "Design", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "Wooden Floor", "Living Room", "0da28dc6-ae72-434e-9e4f-1abd2bd76d01" },
                    { 2, "Decor", "Dinnign Room", "0da28dc6-ae72-434e-9e4f-1abd2bd76d01" },
                    { 3, "Tiles", "BathRoom", "0da28dc6-ae72-434e-9e4f-1abd2bd76d01" }
                });

            migrationBuilder.InsertData(
                table: "ContractorServices",
                columns: new[] { "ContractorServiceId", "ContractorId", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 },
                    { 4, 3, 4 },
                    { 6, 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "FixHome",
                columns: new[] { "FixHomeId", "ContractorId", "Description", "RoomId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, null, 1, "0da28dc6-ae72-434e-9e4f-1abd2bd76d01" },
                    { 2, 4, null, 2, "0da28dc6-ae72-434e-9e4f-1abd2bd76d01" },
                    { 3, 3, null, 2, "0da28dc6-ae72-434e-9e4f-1abd2bd76d01" }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "ImageId", "RoomId", "Source", "StyleId" },
                values: new object[,]
                {
                    { 1, 1, "https://www.iheartnaptime.net/wp-content/uploads/2013/05/wood-floor-designs-2.jpg", 1 },
                    { 2, 2, "https://i.pinimg.com/originals/6b/6c/8d/6b6c8d8a5c415fc8f72d16f439ce6eba.jpg", 2 },
                    { 3, 3, "http://www.therunnerssoul.com/wp-content/uploads/2018/08/traditional-dining-room-decorating-photos-casual-dining-room-decorating-ideas-modern-dining-room-design-pictures.jpg", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contractor_UserId",
                table: "Contractor",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorServices_ContractorId",
                table: "ContractorServices",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractorServices_ServiceId",
                table: "ContractorServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_FixHome_ContractorId",
                table: "FixHome",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_FixHome_RoomId",
                table: "FixHome",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_FixHome_UserId",
                table: "FixHome",
                column: "UserId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Image_RoomId",
                table: "Image",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_StyleId",
                table: "Image",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Room_UserId",
                table: "Room",
                column: "UserId");
        }

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
                name: "ContractorServices");

            migrationBuilder.DropTable(
                name: "FixHome");

            migrationBuilder.DropTable(
                name: "IdeaImage");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Contractor");

            migrationBuilder.DropTable(
                name: "Ideaboard");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Style");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
