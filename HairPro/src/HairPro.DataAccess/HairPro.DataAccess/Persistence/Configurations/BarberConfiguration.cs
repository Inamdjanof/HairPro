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
    public class BarberConfiguration : IEntityTypeConfiguration<Barber>
    {
        public void Configure(EntityTypeBuilder<Barber> builder)
        {
            // Asosiy kalit
            builder.HasKey(b => b.Id);

            // User bilan bog'lash
            builder
                .HasOne(b => b.User)
                .WithMany()  // Agar User o‘zida Barbers kolleksiyasini saqlasa, bu yerda .WithMany(u => u.Barbers) bo‘lishi mumkin.
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // BarberShop bilan bog‘lash
            builder
                .HasOne(b => b.BarberShop)
                .WithMany(bs => bs.Barbers)
                .HasForeignKey(b => b.BarberShopId)
                .OnDelete(DeleteBehavior.Restrict);

            // AverageRating maydoni uchun chegaralar
            builder
                .Property(b => b.AverageRating)
                .HasPrecision(3, 2) // Maksimal 2 ta kasr qismi (masalan: 4.75)
                .HasDefaultValue(0);

            // Audit maydonlari
            builder
                .Property(b => b.CreatedBy)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(b => b.UpdatedBy)
                .HasMaxLength(100)
                .IsRequired(false);

            builder
                .Property(b => b.CreatedOn)
                .IsRequired();

            builder
                .Property(b => b.UpdatedOn)
                .IsRequired(false);
        }


    }
}
