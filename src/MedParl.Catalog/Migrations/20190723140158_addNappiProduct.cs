using Microsoft.EntityFrameworkCore.Migrations;

namespace MedPark.Catalog.Migrations
{
    public partial class addNappiProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NappiCode",
                table: "Product",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NappiCode",
                table: "Product");
        }
    }
}
