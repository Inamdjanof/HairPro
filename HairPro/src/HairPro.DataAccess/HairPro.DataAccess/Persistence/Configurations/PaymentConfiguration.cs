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
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            // Asosiy kalit
            builder.HasKey(p => p.Id);

            // Amount - majburiy va musbat bo‘lishi kerak
            builder
                .Property(p => p.Amount)
                .IsRequired()
                .HasDefaultValue(0);

            // PaymentMethod - majburiy maydon
            builder
                .Property(p => p.PaymentMethod)
                .IsRequired();

            // Status - majburiy maydon
            builder
                .Property(p => p.Status)
                .IsRequired();

            // CreateAt - default vaqt UTC
            builder
                .Property(p => p.CreateAt)
                .HasDefaultValueSql("NOW()");

            // Order bilan bog‘lash
            builder
                .HasOne(p => p.Order)
                .WithMany()
                .HasForeignKey(p => p.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Audit maydonlari
            builder
                .Property(p => p.CreatedBy)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(p => p.CreatedOn)
                .IsRequired();

            builder
                .Property(p => p.UpdatedBy)
                .HasMaxLength(100);

            builder
                .Property(p => p.UpdatedOn)
                .IsRequired(false);
        }
    }

}
