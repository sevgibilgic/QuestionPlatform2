using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestionPlatform2.Migrations
{
    /// <inheritdoc />
    public partial class newmig10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhotoUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhotoUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 0, 8, 22, 414, DateTimeKind.Local).AddTicks(3177), new DateTime(2025, 12, 6, 0, 8, 22, 414, DateTimeKind.Local).AddTicks(3178) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 0, 8, 22, 414, DateTimeKind.Local).AddTicks(3181), new DateTime(2025, 12, 6, 0, 8, 22, 414, DateTimeKind.Local).AddTicks(3182) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 6, 0, 8, 22, 414, DateTimeKind.Local).AddTicks(3184), new DateTime(2025, 12, 6, 0, 8, 22, 414, DateTimeKind.Local).AddTicks(3185) });
        }
    }
}
