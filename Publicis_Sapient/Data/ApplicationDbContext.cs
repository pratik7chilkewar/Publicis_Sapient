using System;
using Microsoft.EntityFrameworkCore;
using Publicis_Sapient.Models;

namespace Publicis_Sapient.Data
{
	public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

        public DbSet<Medicine> Medicines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.HasKey(e => e.MedicineId);

                entity.Property(e => e.MedicineId).UseIdentityColumn();

                entity.Property(e => e.MedicineName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MedicineQuantity)
               .IsRequired();

                entity.Property(e => e.MedicineBrand)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MedicineNotes)
                    .HasMaxLength(1000);

                entity.Property(e => e.MedicinePrice)
                    . IsRequired();

                entity.Property(e => e.MedicineExpireDate)
                    .IsRequired();

            });
                
            modelBuilder.Entity<Medicine>().ToTable("Medicines");
        }

    }
}

