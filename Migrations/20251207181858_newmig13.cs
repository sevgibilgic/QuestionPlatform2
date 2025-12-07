using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestionPlatform2.Migrations
{
    /// <inheritdoc />
    public partial class newmig13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 21, 18, 58, 436, DateTimeKind.Local).AddTicks(1207), new DateTime(2025, 12, 7, 21, 18, 58, 436, DateTimeKind.Local).AddTicks(1208) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 21, 18, 58, 436, DateTimeKind.Local).AddTicks(1212), new DateTime(2025, 12, 7, 21, 18, 58, 436, DateTimeKind.Local).AddTicks(1212) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 21, 18, 58, 436, DateTimeKind.Local).AddTicks(1215), new DateTime(2025, 12, 7, 21, 18, 58, 436, DateTimeKind.Local).AddTicks(1216) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 21, 24, 55, 454, DateTimeKind.Local).AddTicks(25), new DateTime(2025, 12, 6, 21, 24, 55, 454, DateTimeKind.Local).AddTicks(27) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 21, 24, 55, 454, DateTimeKind.Local).AddTicks(31), new DateTime(2025, 12, 6, 21, 24, 55, 454, DateTimeKind.Local).AddTicks(31) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 21, 24, 55, 454, DateTimeKind.Local).AddTicks(34), new DateTime(2025, 12, 6, 21, 24, 55, 454, DateTimeKind.Local).AddTicks(34) });
        }
    }
}
