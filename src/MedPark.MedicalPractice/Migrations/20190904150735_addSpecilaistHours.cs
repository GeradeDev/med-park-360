using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedPark.MedicalPractice.Migrations
{
    public partial class addSpecilaistHours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "PracticeId",
                table: "OperatingHours",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "SpecialistId",
                table: "OperatingHours",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialistId",
                table: "OperatingHours");

            migrationBuilder.AlterColumn<Guid>(
                name: "PracticeId",
                table: "OperatingHours",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
