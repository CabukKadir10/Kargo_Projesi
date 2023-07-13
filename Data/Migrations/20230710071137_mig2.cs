using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CenterId",
                table: "Lines",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 1,
                columns: new[] { "CenterId", "ConcurrencyStamp" },
                values: new object[] { 0, "cc5363d9-e2ad-4d0c-9a23-7cdec5a53097" });

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 2,
                columns: new[] { "CenterId", "ConcurrencyStamp" },
                values: new object[] { 0, "64f53933-5a21-4700-890e-c2d9665a1045" });

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 3,
                columns: new[] { "CenterId", "ConcurrencyStamp" },
                values: new object[] { 0, "72172875-8e9e-49ac-8914-33fe699f0c58" });

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 4,
                columns: new[] { "CenterId", "ConcurrencyStamp" },
                values: new object[] { 0, "d816cabd-7e8a-4d66-880b-f18adb873414" });

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 5,
                columns: new[] { "CenterId", "ConcurrencyStamp" },
                values: new object[] { 0, "488a1d7c-7076-44a7-803d-46ac06be0554" });

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "8f08958e-d224-45d5-bd4f-5c287044f165");

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "20eb8463-00b7-4da2-b01d-a071e7147e3b");

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "b3f4324d-c82a-4231-ae42-b24ed29811d3");

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "bd364afc-9d06-4d6a-9dd8-afd0f696810e");

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "923ba6d3-3a20-4377-a613-7c3b3fe430f4");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "69fc3b04-79de-416b-a277-1e1bac06448d");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "1626ce7c-1211-4035-be88-acb8a5dd5f85");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "c8720fad-b419-4fe1-9563-a428a9d1e026");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "a3637cef-558e-40c0-a1c7-78315645d94c");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "291c80b1-f9ae-4a71-8f1e-4e02c5be9b46");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6,
                column: "ConcurrencyStamp",
                value: "fc7ccdb3-d719-4005-83cb-8a05f5adc7c2");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7,
                column: "ConcurrencyStamp",
                value: "f26deb63-c0f8-4cb3-9132-12d803e9e402");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8,
                column: "ConcurrencyStamp",
                value: "ec231d1e-1891-4e94-932b-5683e4a1d038");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9,
                column: "ConcurrencyStamp",
                value: "cac88b93-edc2-48b6-b739-4449de433846");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10,
                column: "ConcurrencyStamp",
                value: "a67c11a7-d614-40c1-ae5b-b875ac0f09d5");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CenterId",
                table: "Lines");

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "333117a3-27dd-49b1-9c89-f274e6ce7b00");

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "1c81e007-67fa-4a63-9ece-58e46b0e3384");

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "072c8c7b-2dc4-498f-b8dc-1be55099022c");

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "894d841b-2157-43b2-9504-3a64c9467dff");

            migrationBuilder.UpdateData(
                table: "Lines",
                keyColumn: "LineId",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "62d659a8-db12-4c6b-a460-4cb53c3788e1");

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "bd214286-2f94-4161-a3c1-3e603c02de50");

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "49dab973-6253-40d8-815f-cae5c2e924b7");

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "2297c619-2d70-4bbb-b625-87f7a570be4d");

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "e6ecb986-6acc-436b-8924-d32527b1cd8c");

            migrationBuilder.UpdateData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "8f6f60e7-d3da-4bdf-bc84-91b34608529b");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "8dd6b6f0-3be1-430b-b009-03da114c4e83");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "6b49defd-9ac6-4ab6-8c0b-cf80d6d05cf5");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "55ae1691-58e7-4767-bfa4-9bdadd8ec764");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "39dfbe2d-5471-4a42-a92b-05dc5e726582");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "0ec257d1-d894-4039-96cc-a593141ebfd0");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 6,
                column: "ConcurrencyStamp",
                value: "32ee1889-fb71-4114-8fa9-5de56359d5c5");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 7,
                column: "ConcurrencyStamp",
                value: "d10c5145-d66e-42e1-8e32-d0ab57861768");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 8,
                column: "ConcurrencyStamp",
                value: "7244d609-45fc-4b45-a488-e3279d9a7ef6");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 9,
                column: "ConcurrencyStamp",
                value: "7be25bc0-ae37-473d-bc24-dd6802e9b53b");

            migrationBuilder.UpdateData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 10,
                column: "ConcurrencyStamp",
                value: "35b9fa70-68a6-4fab-b51e-730213ec78f4");
        }
    }
}
