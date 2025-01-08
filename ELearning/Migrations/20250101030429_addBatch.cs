using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELearning.Migrations
{
    public partial class addBatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Company_CompanyId",
                table: "Batches");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Batches",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_Batches_CompanyId",
                table: "Batches",
                newName: "IX_Batches_CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Course_CourseId",
                table: "Batches",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Course_CourseId",
                table: "Batches");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Batches",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Batches_CourseId",
                table: "Batches",
                newName: "IX_Batches_CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Company_CompanyId",
                table: "Batches",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
