using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace FabricioAssignment.Migrations
{
    public partial class Add_Content : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "AppContent",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false),
                PageContent = table.Column<string>(maxLength: 2048, nullable: true),
                PageName = table.Column<string>(maxLength: 128, nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_AppContent", x => x.Id);
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppContent");
        }
    }
}
