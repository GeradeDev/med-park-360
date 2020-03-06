using MedPark.Basket.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Basket
{
    public class BasketDBContext : DbContext
    {
        public DbSet<CustomerBasket> Basket { get; set; }
        public DbSet<BasketItem> BasketItem { get; set; }
        public DbSet<Product> Product { get; set; }
        
        public BasketDBContext(DbContextOptions<BasketDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CustomerBasket>().ToTable("Basket");
            builder.Entity<BasketItem>().ToTable("BasketItem");
            builder.Entity<Product>().ToTable("Product");
        }
    }
}
