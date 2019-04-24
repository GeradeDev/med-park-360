using MedPark.Identity.Config;
using MedPark.Identity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Identity
{
    public class MedParkContext : DbContext
    {
        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<ApiResourceEntity> ApiResources { get; set; }
        public DbSet<IdentityResourceEntity> IdentityResources { get; set; }

        public MedParkContext(DbContextOptions<MedParkContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ClientEntity>().HasKey(m => m.ClientId);
            //builder.Entity<ClientEntity>().HasData(IdentityConfig.GetClients());
                
            builder.Entity<ApiResourceEntity>().HasKey(m => m.ApiResourceName);
            //builder.Entity<ApiResourceEntity>().HasData(IdentityConfig.GetApiResources());

            builder.Entity<IdentityResourceEntity>().HasKey(m => m.IdentityResourceName);
            //builder.Entity<IdentityResourceEntity>().HasData(IdentityConfig.GetIdentityResources());
            
            base.OnModelCreating(builder);
        }
    }
}
