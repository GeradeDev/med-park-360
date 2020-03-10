using Microsoft.EntityFrameworkCore.Migrations;

namespace MedPark.Basket.Migrations
{
    public partial class removedProdDetailFromBaskretItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "BasketItem");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "BasketItem");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "BasketItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "BasketItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BasketItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "BasketItem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
