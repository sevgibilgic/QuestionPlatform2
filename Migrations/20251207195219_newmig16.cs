using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestionPlatform2.Migrations
{
    /// <inheritdoc />
    public partial class newmig16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 22, 52, 19, 549, DateTimeKind.Local).AddTicks(2252), new DateTime(2025, 12, 7, 22, 52, 19, 549, DateTimeKind.Local).AddTicks(2253) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 22, 52, 19, 549, DateTimeKind.Local).AddTicks(2257), new DateTime(2025, 12, 7, 22, 52, 19, 549, DateTimeKind.Local).AddTicks(2258) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 22, 52, 19, 549, DateTimeKind.Local).AddTicks(2261), new DateTime(2025, 12, 7, 22, 52, 19, 549, DateTimeKind.Local).AddTicks(2261) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 21, 47, 54, 542, DateTimeKind.Local).AddTicks(4814), new DateTime(2025, 12, 7, 21, 47, 54, 542, DateTimeKind.Local).AddTicks(4815) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 21, 47, 54, 542, DateTimeKind.Local).AddTicks(4818), new DateTime(2025, 12, 7, 21, 47, 54, 542, DateTimeKind.Local).AddTicks(4819) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 21, 47, 54, 542, DateTimeKind.Local).AddTicks(4821), new DateTime(2025, 12, 7, 21, 47, 54, 542, DateTimeKind.Local).AddTicks(4822) });
        }
    }
}
