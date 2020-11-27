using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;
namespace CountryTest.Context
{
    public class CountryContext : DbContext
    {
        public CountryContext()
        {
            //Database.Migrate();
        }
        public CountryContext(DbContextOptions<CountryContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<Country> Country { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-L4P4V05;Database=CountryTest;User Id=login;password=qwerty12;Trusted_Connection = True;MultipleActiveResultSets=true;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>(entity =>
            {
                entity.Property(e => e.ActivityName)
                .IsRequired()
                .IsUnicode(false);

                entity.Property(e => e.ActivityCategory)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasKey(e => e.ActivityId);

                entity.Property(e => e.UniqId)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.UniqId)
                .IsRequired()
                .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Activity)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_Country");
            });
            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.Property(e => e.CityName)
                .IsRequired()
                .IsUnicode(false);

            });
        }

    }
}
