using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELearning.Migrations
{
    public partial class addAppNotifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subject",
                table: "Notifications");

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_SubjectId",
                table: "Notifications",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Subjects_SubjectId",
                table: "Notifications",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Subjects_SubjectId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_SubjectId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Notifications");

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "Notifications",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }
    }
}
