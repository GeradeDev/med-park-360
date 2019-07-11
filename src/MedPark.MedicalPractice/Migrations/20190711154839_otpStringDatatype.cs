using Microsoft.EntityFrameworkCore.Migrations;

namespace MedPark.MedicalPractice.Migrations
{
    public partial class otpStringDatatype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstituteName",
                table: "Qualifications");

            migrationBuilder.AlterColumn<string>(
                name: "OTP",
                table: "PendingRegistration",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InstituteName",
                table: "Qualifications",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "OTP",
                table: "PendingRegistration",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
