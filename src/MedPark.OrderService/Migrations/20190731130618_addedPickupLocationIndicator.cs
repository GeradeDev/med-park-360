using Microsoft.EntityFrameworkCore.Migrations;

namespace MedPark.OrderService.Migrations
{
    public partial class addedPickupLocationIndicator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPickUpLocation",
                table: "CustomerAddress",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_OrderId",
                table: "LineItem",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItem_Order_OrderId",
                table: "LineItem",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItem_Order_OrderId",
                table: "LineItem");

            migrationBuilder.DropIndex(
                name: "IX_LineItem_OrderId",
                table: "LineItem");

            migrationBuilder.DropColumn(
                name: "IsPickUpLocation",
                table: "CustomerAddress");
        }
    }
}
