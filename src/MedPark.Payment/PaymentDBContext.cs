using MedPark.Payment.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Payment
{
    public class PaymentDBContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerPaymentMethod> CustomerPaymentMethod { get; set; }
        public DbSet<OrderPayment> OrderPayment { get; set; }
        public DbSet<PaymentStatus> PaymentStatus { get; set; }
        public DbSet<PaymentType> PaymentType { get; set; }

        public PaymentDBContext(DbContextOptions<PaymentDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>().ToTable("Customer");
            builder.Entity<CustomerPaymentMethod>().ToTable("CustomerPaymentMethod");
            builder.Entity<OrderPayment>().ToTable("OrderPayment");
            builder.Entity<PaymentStatus>().ToTable("PaymentStatus");
            builder.Entity<PaymentType>().ToTable("PaymentType");
        }
    }
}
