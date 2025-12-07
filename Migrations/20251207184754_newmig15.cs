using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestionPlatform2.Migrations
{
    /// <inheritdoc />
    public partial class newmig15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Users_UserId",
                table: "Favorites",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Users_UserId",
                table: "Favorites");

            migrationBuilder.DropIndex(
                name: "IX_Favorites_UserId",
                table: "Favorites");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 21, 24, 41, 570, DateTimeKind.Local).AddTicks(9705), new DateTime(2025, 12, 7, 21, 24, 41, 570, DateTimeKind.Local).AddTicks(9707) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 21, 24, 41, 570, DateTimeKind.Local).AddTicks(9711), new DateTime(2025, 12, 7, 21, 24, 41, 570, DateTimeKind.Local).AddTicks(9711) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 7, 21, 24, 41, 570, DateTimeKind.Local).AddTicks(9714), new DateTime(2025, 12, 7, 21, 24, 41, 570, DateTimeKind.Local).AddTicks(9715) });
        }
    }
}
