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
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            // Asosiy kalit
            builder.HasKey(s => s.Id);

            // Name - majburiy maydon
            builder
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Audit maydonlari
            builder
                .Property(s => s.CreatedBy)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(s => s.CreatedOn)
                .IsRequired();

            builder
                .Property(s => s.UpdatedBy)
                .HasMaxLength(100);

            builder
                .Property(s => s.UpdatedOn)
                .IsRequired(false);
        }
    }
}
