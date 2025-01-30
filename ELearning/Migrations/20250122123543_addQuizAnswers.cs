using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELearning.Migrations
{
    public partial class addQuizAnswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuizAnswers_QuizOptions_OptionId",
                table: "QuizAnswers");

            migrationBuilder.DropIndex(
                name: "IX_QuizAnswers_OptionId",
                table: "QuizAnswers");

            migrationBuilder.AlterColumn<int>(
                name: "OptionId",
                table: "QuizAnswers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Marks",
                table: "QuizAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Marks",
                table: "QuizAnswers");

            migrationBuilder.AlterColumn<int>(
                name: "OptionId",
                table: "QuizAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuizAnswers_OptionId",
                table: "QuizAnswers",
                column: "OptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuizAnswers_QuizOptions_OptionId",
                table: "QuizAnswers",
                column: "OptionId",
                principalTable: "QuizOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
