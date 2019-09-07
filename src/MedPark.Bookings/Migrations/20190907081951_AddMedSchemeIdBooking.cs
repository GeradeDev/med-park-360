using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedPark.Bookings.Migrations
{
    public partial class AddMedSchemeIdBooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MedicalScheme",
                table: "Appointment",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedicalScheme",
                table: "Appointment");
        }
    }
}
