using MedPark.Bookings.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Bookings
{
    public class MedParkBookingContext : DbContext
    {
        DbSet<Appointment> Appointment { get; set; }
        DbSet<Customer> Customer { get; set; }
        DbSet<Specialist> Specialist { get; set; }

        public MedParkBookingContext(DbContextOptions<MedParkBookingContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Appointment>().ToTable("Appointment");
            builder.Entity<Customer>().ToTable("Customer");
            builder.Entity<Specialist>().ToTable("Specialist");
        }
    }
}
