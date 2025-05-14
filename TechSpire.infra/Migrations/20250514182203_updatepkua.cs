using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechSpire.infra.Migrations
{
    /// <inheritdoc />
    public partial class updatepkua : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAnswers",
                table: "UserAnswers");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAnswers",
                table: "UserAnswers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_UserId",
                table: "UserAnswers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAnswers",
                table: "UserAnswers");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswers_UserId",
                table: "UserAnswers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserAnswers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAnswers",
                table: "UserAnswers",
                columns: new[] { "UserId", "QuestionId", "AnswerId" });
        }
    }
}
