using HairPros.Core.Entities;
using HairPros.Core.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.DataAccess.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Asosiy kalit
            builder.HasKey(o => o.Id);

            // TotalAmount - majburiy va musbat qiymat bo‘lishi kerak
            builder
                .Property(o => o.TotalAmount)
                .IsRequired()
                .HasDefaultValue(0);

            // Status - default qiymat Pending
            builder
                .Property(o => o.Status)
                .HasDefaultValue(OrderStatus.Pending);

            // Customer bilan bog‘lash
            builder
                .HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Barber bilan bog‘lash
            builder
                .HasOne(o => o.Barber)
                .WithMany()
                .HasForeignKey(o => o.BarberId)
                .OnDelete(DeleteBehavior.Restrict);

            // Audit maydonlari
            builder
                .Property(o => o.CreatedBy)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(o => o.CreatedOn)
                .IsRequired();

            builder
                .Property(o => o.UpdatedBy)
                .HasMaxLength(100);

            builder
                .Property(o => o.UpdatedOn)
                .IsRequired(false);
        }
    }


}
