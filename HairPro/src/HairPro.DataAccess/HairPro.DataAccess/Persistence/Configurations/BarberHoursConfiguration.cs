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
    public class BarberHoursConfiguration : IEntityTypeConfiguration<BarberHours>
    {
        public void Configure(EntityTypeBuilder<BarberHours> builder)
        {
            // Asosiy kalit
            builder.HasKey(bh => bh.Id);

            // Barber bilan bog'lash
            builder
                .HasOne(bh => bh.Barber)
                .WithMany() // Agar Barber o‘zida BarberHours kolleksiyasini saqlasa, .WithMany(b => b.BarberHours) bo‘lishi mumkin.
                .HasForeignKey(bh => bh.BarberId)
                .OnDelete(DeleteBehavior.Cascade);

            // Haftaning kuni uchun enum sifatida saqlash
            builder
                .Property(bh => bh.DayOfWeek)
                .HasConversion<int>() // Enum DayOfWeek ni int sifatida saqlaydi
                .IsRequired();

            // OpenTime va CloseTime maydonlarini saqlash
            builder
                .Property(bh => bh.OpenTime)
                .IsRequired();

            builder
                .Property(bh => bh.CloseTime)
                .IsRequired();

            // Audit maydonlari
            builder
                .Property(bh => bh.CreatedBy)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(bh => bh.UpdatedBy)
                .HasMaxLength(100)
                .IsRequired(false);

            builder
                .Property(bh => bh.CreatedOn)
                .IsRequired();

            builder
                .Property(bh => bh.UpdatedOn)
                .IsRequired(false);

            // Unikal constraint qo'shish (bir sartarosh har bir kuni faqat bitta ish vaqti belgilashi mumkin)
            builder
                .HasIndex(bh => new { bh.BarberId, bh.DayOfWeek })
                .IsUnique();
        }
    }



}
