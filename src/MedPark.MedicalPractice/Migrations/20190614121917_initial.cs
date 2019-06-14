using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedPark.MedicalPractice.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcceptedMedicalScheme",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    SchemeName = table.Column<string>(nullable: true),
                    SchemeId = table.Column<Guid>(nullable: false),
                    PracticeId = table.Column<Guid>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    DateEffective = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcceptedMedicalScheme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AddressLine3 = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    PractiveId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Credential",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Cellphone = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    SpecialityId = table.Column<Guid>(nullable: true),
                    PracticeId = table.Column<Guid>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false),
                    IsVerfied = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credential", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Institute",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalScheme",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    SchemeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalScheme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperatingHours",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    PracticeId = table.Column<Guid>(nullable: false),
                    SundayOpen = table.Column<DateTime>(nullable: true),
                    SundayClose = table.Column<DateTime>(nullable: true),
                    MondayOpen = table.Column<DateTime>(nullable: true),
                    MondayClose = table.Column<DateTime>(nullable: true),
                    TuesdayOpen = table.Column<DateTime>(nullable: true),
                    TuesdayClose = table.Column<DateTime>(nullable: true),
                    WednesdayOpen = table.Column<DateTime>(nullable: true),
                    WednesdayClose = table.Column<DateTime>(nullable: true),
                    ThursdayOpen = table.Column<DateTime>(nullable: true),
                    ThursdayClose = table.Column<DateTime>(nullable: true),
                    FridayOpen = table.Column<DateTime>(nullable: true),
                    FridayClose = table.Column<DateTime>(nullable: true),
                    SaturdayOpen = table.Column<DateTime>(nullable: true),
                    SaturdayClose = table.Column<DateTime>(nullable: true),
                    PublicHolidayOpen = table.Column<DateTime>(nullable: true),
                    PublicHolidayClose = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingHours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Practice",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    PracticeName = table.Column<string>(nullable: true),
                    Slogan = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    TelephonePrimary = table.Column<string>(nullable: true),
                    TelephoneSecondary = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    LocationLongitude = table.Column<string>(nullable: true),
                    LocationLatitude = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Practice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Qualifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    QualificationName = table.Column<string>(nullable: true),
                    InstituteName = table.Column<string>(nullable: true),
                    InstituteId = table.Column<Guid>(nullable: false),
                    YearObtained = table.Column<DateTime>(nullable: false),
                    CredentialId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Speciality",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speciality", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcceptedMedicalScheme");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Credential");

            migrationBuilder.DropTable(
                name: "Institute");

            migrationBuilder.DropTable(
                name: "MedicalScheme");

            migrationBuilder.DropTable(
                name: "OperatingHours");

            migrationBuilder.DropTable(
                name: "Practice");

            migrationBuilder.DropTable(
                name: "Qualifications");

            migrationBuilder.DropTable(
                name: "Speciality");
        }
    }
}
