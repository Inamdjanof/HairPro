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
    public class ServiceConfiguration : IEntityTypeConfiguration<AllService>
    {
        public void Configure(EntityTypeBuilder<AllService> builder)
        {
            
            builder.HasKey(s => s.Id);

           
            builder
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);

           
        }
    }
}
