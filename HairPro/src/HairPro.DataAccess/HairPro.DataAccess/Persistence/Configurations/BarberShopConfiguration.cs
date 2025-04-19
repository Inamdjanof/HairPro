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
    public class BarberShopConfiguration : IEntityTypeConfiguration<BarberShop>
    {
        public void Configure(EntityTypeBuilder<BarberShop> builder)
        {
            // Asosiy kalit
            builder.HasKey(bs => bs.Id);

            // Name majburiy va maksimal uzunlik 200 ta belgi
            builder
                .Property(bs => bs.Name)
                .IsRequired()
                .HasMaxLength(200);

            // ResponsibleBarberId - Sartaroshxonaning javobgar sartaroshi
            builder
                .Property(bs => bs.ResponsibleBarberId)
                .IsRequired();

            // Location majburiy va maksimal uzunlik 500 ta belgi
            builder
                .Property(bs => bs.Location)
                .IsRequired()
                .HasMaxLength(500);

            // DocumentPath maksimal uzunlik 300 ta belgi
            builder
                .Property(bs => bs.DocumentPath)
                .HasMaxLength(300)
                .IsRequired(false); // Hujjat bo‘lmasligi ham mumkin

            // Sartaroshlar bilan bog‘lash (1 ta BarberShop ko‘p sartaroshga ega bo‘lishi mumkin)
            builder
                .HasMany(bs => bs.Barbers)
                .WithOne(b => b.BarberShop)
                .HasForeignKey(b => b.BarberShopId)
                .OnDelete(DeleteBehavior.Cascade);

         
        }
    }

}
