using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestionPlatform2.Migrations
{
    /// <inheritdoc />
    public partial class newmig11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 20, 44, 0, 277, DateTimeKind.Local).AddTicks(6350), new DateTime(2025, 12, 6, 20, 44, 0, 277, DateTimeKind.Local).AddTicks(6351) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 20, 44, 0, 277, DateTimeKind.Local).AddTicks(6354), new DateTime(2025, 12, 6, 20, 44, 0, 277, DateTimeKind.Local).AddTicks(6355) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 20, 44, 0, 277, DateTimeKind.Local).AddTicks(6358), new DateTime(2025, 12, 6, 20, 44, 0, 277, DateTimeKind.Local).AddTicks(6358) });
        }
    }
}
