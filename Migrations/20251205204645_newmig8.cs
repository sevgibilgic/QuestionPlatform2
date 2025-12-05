using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestionPlatform2.Migrations
{
    /// <inheritdoc />
    public partial class newmig8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 23, 46, 45, 461, DateTimeKind.Local).AddTicks(7227), new DateTime(2025, 12, 5, 23, 46, 45, 461, DateTimeKind.Local).AddTicks(7227) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 23, 46, 45, 461, DateTimeKind.Local).AddTicks(7232), new DateTime(2025, 12, 5, 23, 46, 45, 461, DateTimeKind.Local).AddTicks(7233) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 23, 46, 45, 461, DateTimeKind.Local).AddTicks(7236), new DateTime(2025, 12, 5, 23, 46, 45, 461, DateTimeKind.Local).AddTicks(7236) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 23, 40, 47, 149, DateTimeKind.Local).AddTicks(7938), new DateTime(2025, 12, 5, 23, 40, 47, 149, DateTimeKind.Local).AddTicks(7939) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 23, 40, 47, 149, DateTimeKind.Local).AddTicks(7942), new DateTime(2025, 12, 5, 23, 40, 47, 149, DateTimeKind.Local).AddTicks(7943) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 23, 40, 47, 149, DateTimeKind.Local).AddTicks(7945), new DateTime(2025, 12, 5, 23, 40, 47, 149, DateTimeKind.Local).AddTicks(7946) });
        }
    }
}
