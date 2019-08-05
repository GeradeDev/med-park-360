using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedPark.OrderService.Migrations
{
    public partial class updatePaymentMethodColumnType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PaymentMethod",
                table: "Order",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Order");
        }
    }
}
