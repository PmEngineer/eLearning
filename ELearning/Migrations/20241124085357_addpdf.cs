using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELearning.Migrations
{
    public partial class addpdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PdfFile",
                table: "pdfNotes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PdfFile",
                table: "pdfNotes");
        }
    }
}
