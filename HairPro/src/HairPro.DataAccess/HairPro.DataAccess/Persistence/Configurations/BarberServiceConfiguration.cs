using HairPros.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.DataAccess.Persistence.Configurations
{
    public class BarberServiceConfiguration : IEntityTypeConfiguration<BarberService>
    {
        public void Configure(EntityTypeBuilder<BarberService> builder)
        {
            
            builder.HasKey(bs => bs.Id);

            
            builder
                .HasOne(bs => bs.Barber)
                .WithMany() // Agar Barber o‘zida BarberServices kolleksiyasini saqlasa, .WithMany(b => b.BarberServices) bo‘lishi mumkin.
                .HasForeignKey(bs => bs.BarberId)
                .OnDelete(DeleteBehavior.Cascade);

            // Service bilan bog'lash
            builder
                .HasOne(bs => bs.Service)
                .WithMany()
                .HasForeignKey(bs => bs.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);

            // Price uchun majburiy va ijobiy qiymat
            builder
                .Property(bs => bs.Price)
                .IsRequired()
                .HasColumnType("decimal(10,2)")
                .HasDefaultValue(0);

           
            builder
                .HasIndex(bs => new { bs.BarberId, bs.ServiceId })
                .IsUnique();
        }
    }
}

