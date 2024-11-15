using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELearning.Migrations
{
    public partial class tblstudentinfoUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "StudentInfo",
                newName: "UserName");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "StudentInfo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "StudentInfo");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "StudentInfo",
                newName: "Name");
        }
    }
}
