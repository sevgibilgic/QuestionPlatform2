using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuestionPlatform2.Migrations
{
    /// <inheritdoc />
    public partial class newmig19 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Questions");
        }
    }
}
