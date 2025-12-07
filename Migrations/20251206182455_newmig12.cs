using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestionPlatform2.Migrations
{
    /// <inheritdoc />
    public partial class newmig12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 20, 49, 40, 874, DateTimeKind.Local).AddTicks(7653), new DateTime(2025, 12, 6, 20, 49, 40, 874, DateTimeKind.Local).AddTicks(7656) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 20, 49, 40, 874, DateTimeKind.Local).AddTicks(7667), new DateTime(2025, 12, 6, 20, 49, 40, 874, DateTimeKind.Local).AddTicks(7669) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 20, 49, 40, 874, DateTimeKind.Local).AddTicks(7677), new DateTime(2025, 12, 6, 20, 49, 40, 874, DateTimeKind.Local).AddTicks(7679) });
        }
    }
}
