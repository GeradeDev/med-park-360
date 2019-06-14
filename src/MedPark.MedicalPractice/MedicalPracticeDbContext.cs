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
        public DbSet<Credential> Credential { get; set; }

        public MedicalPracticeDbContext(DbContextOptions<MedicalPracticeDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Practice>().ToTable("Practice");
            builder.Entity<Credential>().ToTable("Credential");
        }
    }
}
