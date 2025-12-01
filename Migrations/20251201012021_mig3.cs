using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestionPlatform2.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Answers",
                newName: "AnswerContent");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 1, 4, 20, 20, 889, DateTimeKind.Local).AddTicks(8726), new DateTime(2025, 12, 1, 4, 20, 20, 889, DateTimeKind.Local).AddTicks(8737) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 1, 4, 20, 20, 889, DateTimeKind.Local).AddTicks(8739), new DateTime(2025, 12, 1, 4, 20, 20, 889, DateTimeKind.Local).AddTicks(8740) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 1, 4, 20, 20, 889, DateTimeKind.Local).AddTicks(8742), new DateTime(2025, 12, 1, 4, 20, 20, 889, DateTimeKind.Local).AddTicks(8743) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnswerContent",
                table: "Answers",
                newName: "Content");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 1, 2, 49, 47, 631, DateTimeKind.Local).AddTicks(7815), new DateTime(2025, 12, 1, 2, 49, 47, 631, DateTimeKind.Local).AddTicks(7832) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 1, 2, 49, 47, 631, DateTimeKind.Local).AddTicks(7835), new DateTime(2025, 12, 1, 2, 49, 47, 631, DateTimeKind.Local).AddTicks(7836) });

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 12, 1, 2, 49, 47, 631, DateTimeKind.Local).AddTicks(7838), new DateTime(2025, 12, 1, 2, 49, 47, 631, DateTimeKind.Local).AddTicks(7838) });
        }
    }
}
