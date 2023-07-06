using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class deneme25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Units",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "00c3a7f0-9a1d-442e-91b6-29ea082f47a9");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "68d2b2a7-9579-4ddf-a2d4-7c440adf9ae7");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "2cad2f71-11d7-45a0-aac3-1c3e330175fc");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "0ea07e01-2cdc-4432-b5ed-779984ef932a");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "247789dc-8d09-4b85-aa84-42494666672a");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6,
                column: "ConcurrencyStamp",
                value: "cccb00a7-a6e9-4ab8-99bd-ce784869d788");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7,
                column: "ConcurrencyStamp",
                value: "b8c19613-202c-4b2f-bd92-7956b2f885ca");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8,
                column: "ConcurrencyStamp",
                value: "84b3fb25-ce01-4809-a2f9-8745f606e153");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9,
                column: "ConcurrencyStamp",
                value: "9966d628-8e03-42b3-b3f6-dfb7cb1c63c2");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10,
                column: "ConcurrencyStamp",
                value: "e8f057dc-7d99-429a-998d-a4bcc97d0582");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Units");
        }
    }
}
