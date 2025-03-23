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

    public class BarberRatingConfiguration : IEntityTypeConfiguration<BarberRating>
    {
        public void Configure(EntityTypeBuilder<BarberRating> builder)
        {
            // Asosiy kalit
            builder.HasKey(br => br.Id);

            // Barber bilan bog'lash
            builder
                .HasOne(br => br.Barber)
                .WithMany() // Agar Barber o‘zida BarberRatings kolleksiyasini saqlasa, .WithMany(b => b.BarberRatings) bo‘lishi mumkin.
                .HasForeignKey(br => br.BarberId)
                .OnDelete(DeleteBehavior.Cascade);

            // Customer bilan bog'lash
            builder
                .HasOne(br => br.Customer)
                .WithMany()
                .HasForeignKey(br => br.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            // Rating maydoni 1-5 oralig'ida bo'lishi shart
            builder
                .Property(br => br.Rating)
                .IsRequired()
                .HasColumnType("smallint")
                .HasDefaultValue(1);

            // Comment maydoni ixtiyoriy, maksimal uzunlik 500
            builder
                .Property(br => br.Comment)
                .HasMaxLength(500)
                .IsRequired(false);

            // Audit maydonlari
            builder
                .Property(br => br.CreatedBy)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(br => br.UpdatedBy)
                .HasMaxLength(100)
                .IsRequired(false);

            builder
                .Property(br => br.CreatedOn)
                .IsRequired();

            builder
                .Property(br => br.UpdatedOn)
                .IsRequired(false);

            // Unikal constraint qo'shish (har bir mijoz har bir sartaroshni faqat bir marta baholay olishi kerak)
            builder
                .HasIndex(br => new { br.BarberId, br.CustomerId })
                .IsUnique();
        }
    }


}
