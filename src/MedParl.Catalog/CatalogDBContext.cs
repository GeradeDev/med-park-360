using MedPark.Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Catalog
{
    public class CatalogDBContext : DbContext
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductCatalog> ProductCatalog { get; set; }

        public CatalogDBContext(DbContextOptions<CatalogDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>().ToTable("Product");
            builder.Entity<Category>().ToTable("Category");
            builder.Entity<ProductCatalog>().ToTable("ProductCatalog");
        }
    }
}
