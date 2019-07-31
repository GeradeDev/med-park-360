using MedPark.OrderService.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.OrderService
{
    public class OrderingDbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerAddress> CustomerAddress { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<LineItem> LineItem { get; set; }

        public OrderingDbContext(DbContextOptions<OrderingDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>().ToTable("Customer");
            builder.Entity<CustomerAddress>().ToTable("CustomerAddress");
            builder.Entity<Order>().ToTable("Order");
            builder.Entity<LineItem>().ToTable("LineItem");
        }
    }
}
