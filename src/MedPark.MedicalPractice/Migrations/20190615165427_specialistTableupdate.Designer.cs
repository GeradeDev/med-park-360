﻿// <auto-generated />
using System;
using MedPark.MedicalPractice;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MedPark.MedicalPractice.Migrations
{
    [DbContext(typeof(MedicalPracticeDbContext))]
    [Migration("20190615165427_specialistTableupdate")]
    partial class specialistTableupdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MedPark.MedicalPractice.Domain.AcceptedMedicalScheme", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("DateEffective");

                    b.Property<DateTime>("DateEnd");

                    b.Property<bool>("IsActive");

                    b.Property<DateTime>("Modified");

                    b.Property<Guid>("PracticeId");

                    b.Property<Guid>("SchemeId");

                    b.Property<string>("SchemeName");

                    b.HasKey("Id");

                    b.ToTable("AcceptedMedicalScheme");
                });

            modelBuilder.Entity("MedPark.MedicalPractice.Domain.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("AddressLine3");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("PostalCode");

                    b.Property<Guid>("PractiveId");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("MedPark.MedicalPractice.Domain.Institute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Institute");
                });

            modelBuilder.Entity("MedPark.MedicalPractice.Domain.MedicalScheme", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("SchemeName");

                    b.HasKey("Id");

                    b.ToTable("MedicalScheme");
                });

            modelBuilder.Entity("MedPark.MedicalPractice.Domain.OperatingHours", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime?>("FridayClose");

                    b.Property<DateTime?>("FridayOpen");

                    b.Property<DateTime>("Modified");

                    b.Property<DateTime?>("MondayClose");

                    b.Property<DateTime?>("MondayOpen");

                    b.Property<Guid>("PracticeId");

                    b.Property<DateTime?>("PublicHolidayClose");

                    b.Property<DateTime?>("PublicHolidayOpen");

                    b.Property<DateTime?>("SaturdayClose");

                    b.Property<DateTime?>("SaturdayOpen");

                    b.Property<DateTime?>("SundayClose");

                    b.Property<DateTime?>("SundayOpen");

                    b.Property<DateTime?>("ThursdayClose");

                    b.Property<DateTime?>("ThursdayOpen");

                    b.Property<DateTime?>("TuesdayClose");

                    b.Property<DateTime?>("TuesdayOpen");

                    b.Property<DateTime?>("WednesdayClose");

                    b.Property<DateTime?>("WednesdayOpen");

                    b.HasKey("Id");

                    b.ToTable("OperatingHours");
                });

            modelBuilder.Entity("MedPark.MedicalPractice.Domain.Practice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Avatar");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email");

                    b.Property<string>("LocationLatitude");

                    b.Property<string>("LocationLongitude");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("PracticeName");

                    b.Property<string>("Slogan");

                    b.Property<string>("TelephonePrimary");

                    b.Property<string>("TelephoneSecondary");

                    b.Property<string>("Website");

                    b.HasKey("Id");

                    b.ToTable("Practice");
                });

            modelBuilder.Entity("MedPark.MedicalPractice.Domain.Qualifications", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<Guid>("CredentialId");

                    b.Property<Guid>("InstituteId");

                    b.Property<string>("InstituteName");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("QualificationName");

                    b.Property<DateTime>("YearObtained");

                    b.HasKey("Id");

                    b.ToTable("Qualifications");
                });

            modelBuilder.Entity("MedPark.MedicalPractice.Domain.Specialist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Avatar");

                    b.Property<string>("Cellphone");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsAdmin");

                    b.Property<bool>("IsVerfied");

                    b.Property<DateTime>("Modified");

                    b.Property<Guid>("PracticeId");

                    b.Property<Guid?>("SpecialityId");

                    b.Property<string>("Surname");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Specialist");
                });

            modelBuilder.Entity("MedPark.MedicalPractice.Domain.Speciality", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Speciality");
                });
#pragma warning restore 612, 618
        }
    }
}
