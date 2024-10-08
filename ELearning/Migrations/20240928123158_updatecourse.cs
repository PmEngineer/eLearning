using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELearning.Migrations
{
    public partial class updatecourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Course",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Course",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Support",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Support",
                table: "Course");
        }
    }
}
