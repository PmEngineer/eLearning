using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELearning.Migrations
{
    public partial class addbatchsub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BatchId",
                table: "BatchSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BatchSubjects_BatchId",
                table: "BatchSubjects",
                column: "BatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_BatchSubjects_Batches_BatchId",
                table: "BatchSubjects",
                column: "BatchId",
                principalTable: "Batches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatchSubjects_Batches_BatchId",
                table: "BatchSubjects");

            migrationBuilder.DropIndex(
                name: "IX_BatchSubjects_BatchId",
                table: "BatchSubjects");

            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "BatchSubjects");
        }
    }
}
