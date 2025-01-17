using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELearning.Migrations
{
    public partial class addbatchclasss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatchClass_Faculties_FacultyId",
                table: "BatchClass");

            migrationBuilder.DropIndex(
                name: "IX_BatchClass_FacultyId",
                table: "BatchClass");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "BatchClass");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "BatchClass",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BatchClass_FacultyId",
                table: "BatchClass",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_BatchClass_Faculties_FacultyId",
                table: "BatchClass",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
