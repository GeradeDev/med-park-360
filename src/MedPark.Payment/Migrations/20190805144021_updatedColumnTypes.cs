using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedPark.Payment.Migrations
{
    public partial class updatedColumnTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "OrderPaymentTypeId",
                table: "OrderPayment",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<int>(
                name: "PaymentCardType",
                table: "CustomerPaymentMethod",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "OrderPaymentTypeId",
                table: "OrderPayment",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaymentCardType",
                table: "CustomerPaymentMethod",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
