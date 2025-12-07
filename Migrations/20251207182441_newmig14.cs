using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestionPlatform2.Migrations
{
    /// <inheritdoc />
    public partial class newmig14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_QuestionId",
                table: "Favorites",
                column: "QuestionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Favorites");

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
    }
}
