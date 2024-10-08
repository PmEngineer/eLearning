using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ELearning.Migrations
{
    public partial class addmenusubmenucourse_tbls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Validity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fee = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISPaid = table.Column<bool>(type: "bit", nullable: true),
                    ISLive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainMenus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainMenuName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MenuURL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MenuPriority = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsMenuActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainMenus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubMenus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainMenuId = table.Column<int>(type: "int", nullable: false),
                    SubMenuName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MenuUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MenuPriority = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsSubMenuActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubMenus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubMenus_MainMenus_MainMenuId",
                        column: x => x.MainMenuId,
                        principalTable: "MainMenus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubMenus_MainMenuId",
                table: "SubMenus",
                column: "MainMenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "SubMenus");

            migrationBuilder.DropTable(
                name: "MainMenus");
        }
    }
}
