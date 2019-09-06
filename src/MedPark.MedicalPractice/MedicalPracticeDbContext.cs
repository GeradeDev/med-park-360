using MedPark.MedicalPractice.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice
{
    public class MedicalPracticeDbContext : DbContext
    {
        public DbSet<Practice> Practice { get; set; }
        public DbSet<Specialist> Specialist { get; set; }
        public DbSet<OperatingHours> OperatingHours { get; set; }
        public DbSet<Qualifications> Qualifications { get; set; }
        public DbSet<AcceptedMedicalScheme> AcceptedMedicalScheme { get; set; }
        public DbSet<MedicalScheme> MedicalScheme { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Institute> Institute { get; set; }
        public DbSet<Speciality> Speciality { get; set; }
        public DbSet<PendingRegistration> PendingRegistration { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<AppointmentType> AppointmentType { get; set; }
        public DbSet<AppointmentAccepted> AppointmentAccepted { get; set; }

        public MedicalPracticeDbContext(DbContextOptions<MedicalPracticeDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Practice>().ToTable("Practice");
            builder.Entity<Specialist>().ToTable("Specialist");
            builder.Entity<OperatingHours>().ToTable("OperatingHours");
            builder.Entity<Qualifications>().ToTable("Qualifications");
            builder.Entity<AcceptedMedicalScheme>().ToTable("AcceptedMedicalScheme");
            builder.Entity<MedicalScheme>().ToTable("MedicalScheme");
            builder.Entity<Address>().ToTable("Address");
            builder.Entity<Institute>().ToTable("Institute");
            builder.Entity<Speciality>().ToTable("Speciality");
            builder.Entity<PendingRegistration>().ToTable("PendingRegistration");
            builder.Entity<Customer>().ToTable("Customer");
            builder.Entity<AppointmentType>().ToTable("AppointmentType");
            builder.Entity<AppointmentAccepted>().ToTable("AppointmentAccepted");
        }
    }
}
