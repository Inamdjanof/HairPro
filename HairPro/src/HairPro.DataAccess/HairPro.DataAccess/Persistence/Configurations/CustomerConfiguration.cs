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

    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Asosiy kalit
            builder.HasKey(c => c.Id);

            // UserId - majburiy maydon
            builder
                .Property(c => c.UserId)
                .IsRequired();

            // Name - majburiy va maksimal uzunlik belgilandi
            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            // User bilan bog‘lash
            builder
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Audit maydonlari
            builder
                .Property(c => c.CreatedBy)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(c => c.UpdatedBy)
                .HasMaxLength(100)
                .IsRequired(false);

            builder
                .Property(c => c.CreatedOn)
                .IsRequired();

            builder
                .Property(c => c.UpdatedOn)
                .IsRequired(false);
        }
    }


}
