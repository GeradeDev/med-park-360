using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedPark.Bookings.Migrations
{
    public partial class updateMedSchemeNoType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MedicalAidMembershipNo",
                table: "Appointment",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "MedicalAidMembershipNo",
                table: "Appointment",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
