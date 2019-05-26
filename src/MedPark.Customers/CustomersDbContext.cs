using MedPark.CustomersService.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.CustomersService
{
    public class CustomersDbContext : DbContext
    {
        public DbSet<Customer> Customers {get;set;}
        public DbSet<Address> Address { get; set; }

        public CustomersDbContext(DbContextOptions<CustomersDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>().ToTable("Customers");
            builder.Entity<Address>().ToTable("Address");
        }
    }
}
