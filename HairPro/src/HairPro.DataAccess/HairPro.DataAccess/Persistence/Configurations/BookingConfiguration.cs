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
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            // Asosiy kalit
            builder.HasKey(b => b.Id);

            // OrderId - majburiy maydon
            builder
                .Property(b => b.OrderId)
                .IsRequired();

            // BarberServiceId - majburiy maydon
            builder
                .Property(b => b.BarberServiceId)
                .IsRequired();

            // BookingTime - majburiy maydon
            builder
                .Property(b => b.BookingTime)
                .IsRequired();

            // IsConfirmed - default false
            builder
                .Property(b => b.IsConfirmed)
                .HasDefaultValue(false);

            // Order bilan bog‘lash
            builder
                .HasOne(b => b.Order)
                .WithMany(o => o.Bookings)
                .HasForeignKey(b => b.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // BarberService bilan bog‘lash
            builder
                .HasOne(b => b.BarberService)
                .WithMany()
                .HasForeignKey(b => b.BarberServiceId)
                .OnDelete(DeleteBehavior.Restrict);

           
        }
    }


}
