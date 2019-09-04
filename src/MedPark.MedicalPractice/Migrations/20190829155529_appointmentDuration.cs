using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedPark.MedicalPractice.Migrations
{
    public partial class appointmentDuration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "AppointmentDuration",
                table: "Specialist",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentDuration",
                table: "Specialist");
        }
    }
}
