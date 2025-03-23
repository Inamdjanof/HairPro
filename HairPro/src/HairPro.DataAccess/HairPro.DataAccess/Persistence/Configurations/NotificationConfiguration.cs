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
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            // Asosiy kalit
            builder.HasKey(n => n.Id);

            // Message - majburiy va maksimal uzunlik belgilandi
            builder
                .Property(n => n.Message)
                .IsRequired()
                .HasMaxLength(500);

            // IsRead - default false
            builder
                .Property(n => n.IsRead)
                .HasDefaultValue(false);

            // CreatedAt - majburiy maydon
            builder
                .Property(n => n.CreatedAt)
                .IsRequired();

            // User bilan bog‘lash
            builder
                .HasOne(n => n.User)
                .WithMany()
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
