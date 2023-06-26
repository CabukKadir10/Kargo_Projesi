using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class mig11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lines",
                columns: table => new
                {
                    LineId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LineName = table.Column<string>(type: "text", nullable: false),
                    LineType = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lines", x => x.LineId);
                });

            migrationBuilder.CreateTable(
                name: "TransferCenters",
                columns: table => new
                {
                    UnitId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UnitName = table.Column<string>(type: "text", nullable: false),
                    ResponsibleName = table.Column<string>(type: "text", nullable: false),
                    ResponsibleSurname = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Gsm = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    District = table.Column<string>(type: "text", nullable: false),
                    NeighBourHood = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    AddressDetail = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferCenters", x => x.UnitId);
                });

            migrationBuilder.CreateTable(
                name: "Station",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StationName = table.Column<string>(type: "text", nullable: false),
                    OrderNumber = table.Column<int>(type: "integer", nullable: false),
                    LineId = table.Column<int>(type: "integer", nullable: false),
                    UnitId = table.Column<int>(type: "integer", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Agentas",
                columns: table => new
                {
                    UnitId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CenterId = table.Column<int>(type: "integer", nullable: false),
                    UnitName = table.Column<string>(type: "text", nullable: false),
                    ResponsibleName = table.Column<string>(type: "text", nullable: false),
                    ResponsibleSurname = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Gsm = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    District = table.Column<string>(type: "text", nullable: false),
                    NeighBourHood = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    AddressDetail = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agentas", x => x.UnitId);
                    table.ForeignKey(
                        name: "FK_Agentas_TransferCenters_CenterId",
                        column: x => x.CenterId,
                        principalTable: "TransferCenters",
                        principalColumn: "UnitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Lines",
                columns: new[] { "LineId", "IsActive", "LineName", "LineType" },
                values: new object[,]
                {
                    { 1, true, "Diyarbakır Hattı", 1 },
                    { 2, true, "Mardin Hattı", 1 },
                    { 3, true, "Mersin Hattı", 1 },
                    { 4, true, "Ankara Hattı", 1 },
                    { 5, true, "İstanbul Hattı", 1 }
                });

            migrationBuilder.InsertData(
                table: "TransferCenters",
                columns: new[] { "UnitId", "AddressDetail", "City", "Description", "District", "Email", "Gsm", "NeighBourHood", "PhoneNumber", "ResponsibleName", "ResponsibleSurname", "Street", "UnitName" },
                values: new object[,]
                {
                    { 1, "Amed merkez", "Diyarbakır", "Description", "Bağlar", "kadir@gmail.com", "085012356", "mahalle1", "05123456789", "kadir", "Çabuk", "sokak1", "Name1" },
                    { 2, "Mardin merkez", "Mardin", "Description", "Bağlar", "muaz@gmail.com", "085012356", "mahalle1", "05123456789", "muaz", "Çabuk", "sokak1", "Name2" },
                    { 3, "Konya merkez", "Konya", "Description", "Bağlar", "yusuf@gmail.com", "085012356", "mahalle1", "05123456789", "yusuf", "Çabuk", "sokak1", "Name3" },
                    { 4, "Ankara merkez", "Ankara", "Description", "Bağlar", "ahmet@gmail.com", "085012356", "mahalle1", "05123456789", "ahmet", "Çabuk", "sokak1", "Name4" },
                    { 5, "İstanbul merkez", "İstanbul", "Description", "Bağlar", "mehmet@gmail.com", "085012356", "mahalle1", "05123456789", "mehmet", "Çabuk", "sokak1", "Name5" }
                });

            migrationBuilder.InsertData(
                table: "Agentas",
                columns: new[] { "UnitId", "AddressDetail", "CenterId", "City", "Description", "District", "Email", "Gsm", "NeighBourHood", "PhoneNumber", "ResponsibleName", "ResponsibleSurname", "Street", "UnitName" },
                values: new object[,]
                {
                    { 6, "Amed merkez", 1, "Diyarbakır", "Description", "Bağlar", "kadir@gmail.com", "085012356", "mahalle1", "05123456789", "kadir", "Çabuk", "sokak1", "agenta1" },
                    { 7, "Amed merkez", 2, "Diyarbakır", "Description", "Bağlar", "kadir@gmail.com", "085012356", "mahalle1", "05123456789", "kadir", "Çabuk", "sokak1", "agenta2" },
                    { 8, "Amed merkez", 2, "Diyarbakır", "Description", "Bağlar", "kadir@gmail.com", "085012356", "mahalle1", "05123456789", "kadir", "Çabuk", "sokak1", "agenta3" },
                    { 9, "Amed merkez", 1, "Diyarbakır", "Description", "Bağlar", "kadir@gmail.com", "085012356", "mahalle1", "05123456789", "kadir", "Çabuk", "sokak1", "agenta4" },
                    { 10, "Amed merkez", 1, "Diyarbakır", "Description", "Bağlar", "kadir@gmail.com", "085012356", "mahalle1", "05123456789", "kadir", "Çabuk", "sokak1", "agenta5" }
                });

            migrationBuilder.InsertData(
                table: "Station",
                columns: new[] { "Id", "LineId", "OrderNumber", "StationName", "UnitId" },
                values: new object[,]
                {
                    { 1, 1, 1, "durak1", 1 },
                    { 2, 1, 2, "durak2", 2 },
                    { 3, 1, 3, "durak3", 3 },
                    { 4, 2, 1, "durak4", 4 },
                    { 5, 2, 2, "durak5", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agentas_CenterId",
                table: "Agentas",
                column: "CenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Station_LineId",
                table: "Station",
                column: "LineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agentas");

            migrationBuilder.DropTable(
                name: "Station");

            migrationBuilder.DropTable(
                name: "TransferCenters");

            migrationBuilder.DropTable(
                name: "Lines");
        }
    }
}
