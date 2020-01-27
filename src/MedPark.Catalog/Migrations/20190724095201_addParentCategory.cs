using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedPark.Catalog.Migrations
{
    public partial class addParentCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentCategory",
                table: "Category",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentCategory",
                table: "Category");
        }
    }
}
