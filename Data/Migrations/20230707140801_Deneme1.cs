using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Deneme1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    District = table.Column<string>(type: "text", nullable: true),
                    Roles = table.Column<string>(type: "text", nullable: false),
                    UnitId = table.Column<int>(type: "integer", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
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
                name: "Lines",
                columns: table => new
                {
                    LineId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LineName = table.Column<string>(type: "text", nullable: false),
                    LineType = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lines", x => x.LineId);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UnitName = table.Column<string>(type: "text", nullable: false),
                    ManagerName = table.Column<string>(type: "text", nullable: false),
                    ManagerSurname = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Gsm = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    District = table.Column<string>(type: "text", nullable: false),
                    NeighBourHood = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    AddressDetail = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    CenterId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Units_Units_CenterId",
                        column: x => x.CenterId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
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
                    UserId = table.Column<int>(type: "integer", nullable: false)
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
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
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
                    UserId = table.Column<int>(type: "integer", nullable: false),
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
                name: "Station",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StationName = table.Column<string>(type: "text", nullable: false),
                    OrderNumber = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    LineId = table.Column<int>(type: "integer", nullable: false),
                    UnitId = table.Column<int>(type: "integer", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Station_Lines_LineId",
                        column: x => x.LineId,
                        principalTable: "Lines",
                        principalColumn: "LineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Station_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, null, "Agenta", "AGENTA" },
                    { 2, null, "TransferCenter", "CENTER" },
                    { 3, null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Lines",
                columns: new[] { "LineId", "ConcurrencyStamp", "IsActive", "LineName", "LineType" },
                values: new object[,]
                {
                    { 1, "43fa21d2-547a-41bf-b83f-3b2e19af02fb", true, "Diyarbakır Hattı", 1 },
                    { 2, "9b48f6b3-e00d-4550-aca1-0f223be8023c", true, "Mardin Hattı", 1 },
                    { 3, "81e0560b-bea9-478b-b24b-1d1929f02ad0", true, "Mersin Hattı", 1 },
                    { 4, "bb7dfd1d-6df5-49ef-8b7a-40f76b6da04e", true, "Ankara Hattı", 1 },
                    { 5, "af2a8fb5-60b7-4ae4-aac2-fd615e7804d1", true, "İstanbul Hattı", 2 }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "AddressDetail", "City", "ConcurrencyStamp", "Description", "Discriminator", "District", "Email", "Gsm", "IsDeleted", "ManagerName", "ManagerSurname", "NeighBourHood", "PhoneNumber", "Street", "UnitName" },
                values: new object[,]
                {
                    { 1, "Amed merkez", "Diyarbakır", "13784c1e-864a-402f-b387-80d31be4b934", "Description", "TransferCenter", "Bağlar", "kadir@gmail.com", "085012356", false, "kadir", "Çabuk", "mahalle1", "05123456789", "sokak1", "Name1" },
                    { 2, "Mardin merkez", "Mardin", "b31f174d-ffc3-4b1b-b6ba-7c1e2d3ef974", "Description", "TransferCenter", "Bağlar", "muaz@gmail.com", "085012356", false, "muaz", "Çabuk", "mahalle1", "05123456789", "sokak1", "Name2" },
                    { 3, "Konya merkez", "Konya", "2094e16d-9cde-42b4-a07a-8905ad66101f", "Description", "TransferCenter", "Bağlar", "yusuf@gmail.com", "085012356", false, "yusuf", "Çabuk", "mahalle1", "05123456789", "sokak1", "Name3" },
                    { 4, "Ankara merkez", "Ankara", "70fe84f2-6305-4aad-832a-137056407f60", "Description", "TransferCenter", "Bağlar", "ahmet@gmail.com", "085012356", false, "ahmet", "Çabuk", "mahalle1", "05123456789", "sokak1", "Name4" },
                    { 5, "İstanbul merkez", "İstanbul", "704bdf06-e668-40d8-a73a-f815bbba8247", "Description", "TransferCenter", "Bağlar", "mehmet@gmail.com", "085012356", false, "mehmet", "Çabuk", "mahalle1", "05123456789", "sokak1", "Name5" }
                });

            migrationBuilder.InsertData(
                table: "Station",
                columns: new[] { "Id", "ConcurrencyStamp", "IsActive", "LineId", "OrderNumber", "StationName", "UnitId" },
                values: new object[,]
                {
                    { 1, "2983b66a-7612-4429-9e8d-399c97cbf70a", true, 1, 1, "durak1", 1 },
                    { 2, "cafe0668-a6e2-4406-811b-b1e69d3c6534", true, 1, 2, "durak2", 2 },
                    { 3, "5d4c2575-1c26-465f-ac0f-fa2b4327c875", true, 1, 3, "durak3", 3 },
                    { 4, "5bf96a40-efc9-426c-b2c0-39599c744db4", true, 2, 1, "durak4", 4 },
                    { 5, "1bc6d9e5-dcdc-4544-8f73-341e28139f46", true, 2, 2, "durak5", 5 }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "AddressDetail", "CenterId", "City", "ConcurrencyStamp", "Description", "Discriminator", "District", "Email", "Gsm", "IsDeleted", "ManagerName", "ManagerSurname", "NeighBourHood", "PhoneNumber", "Street", "UnitName" },
                values: new object[,]
                {
                    { 6, "Amed merkez", 1, "Diyarbakır", "6a89837b-ddf3-49e4-96af-bddc9fbf49e3", "Description", "Agenta", "Bağlar", "kadir@gmail.com", "085012356", false, "kadir", "Çabuk", "mahalle1", "05123456789", "sokak1", "agenta1" },
                    { 7, "Amed merkez", 1, "Diyarbakır", "2bf58eeb-edbd-48e8-a87a-7a0ac3146bf7", "Description", "Agenta", "Bağlar", "kadir@gmail.com", "085012356", false, "kadir", "Çabuk", "mahalle1", "05123456789", "sokak1", "agenta2" },
                    { 8, "Amed merkez", 1, "Diyarbakır", "452873ad-87a9-4deb-800c-cd4c86ea4446", "Description", "Agenta", "Bağlar", "kadir@gmail.com", "085012356", false, "kadir", "Çabuk", "mahalle1", "05123456789", "sokak1", "agenta3" },
                    { 9, "Amed merkez", 1, "Diyarbakır", "168ccfae-04b8-4f31-abe0-f6cec83efc68", "Description", "Agenta", "Bağlar", "kadir@gmail.com", "085012356", false, "kadir", "Çabuk", "mahalle1", "05123456789", "sokak1", "agenta4" },
                    { 10, "Amed merkez", 1, "Diyarbakır", "7c724ffa-83c8-4e20-a810-0ef569c8a88d", "Description", "Agenta", "Bağlar", "kadir@gmail.com", "085012356", false, "kadir", "Çabuk", "mahalle1", "05123456789", "sokak1", "agenta5" }
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
                name: "IX_Station_LineId",
                table: "Station",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_Station_UnitId",
                table: "Station",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_CenterId",
                table: "Units",
                column: "CenterId");
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
                name: "Station");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Lines");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
