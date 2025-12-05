using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestionPlatform2.Migrations
{
    /// <inheritdoc />
    public partial class newmig7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 22, 46, 7, 982, DateTimeKind.Local).AddTicks(9432), new DateTime(2025, 12, 5, 22, 46, 7, 982, DateTimeKind.Local).AddTicks(9433) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 22, 46, 7, 982, DateTimeKind.Local).AddTicks(9436), new DateTime(2025, 12, 5, 22, 46, 7, 982, DateTimeKind.Local).AddTicks(9437) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 22, 46, 7, 982, DateTimeKind.Local).AddTicks(9439), new DateTime(2025, 12, 5, 22, 46, 7, 982, DateTimeKind.Local).AddTicks(9440) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 22, 40, 52, 99, DateTimeKind.Local).AddTicks(1667), new DateTime(2025, 12, 5, 22, 40, 52, 99, DateTimeKind.Local).AddTicks(1668) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 22, 40, 52, 99, DateTimeKind.Local).AddTicks(1672), new DateTime(2025, 12, 5, 22, 40, 52, 99, DateTimeKind.Local).AddTicks(1672) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 5, 22, 40, 52, 99, DateTimeKind.Local).AddTicks(1675), new DateTime(2025, 12, 5, 22, 40, 52, 99, DateTimeKind.Local).AddTicks(1675) });
        }
    }
}
