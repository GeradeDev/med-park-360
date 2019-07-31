using Microsoft.EntityFrameworkCore.Migrations;

namespace MedPark.OrderService.Migrations
{
    public partial class addedPickupLocationIndicatorUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsPickUpLocation",
                table: "CustomerAddress",
                nullable: true,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsPickUpLocation",
                table: "CustomerAddress",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}
