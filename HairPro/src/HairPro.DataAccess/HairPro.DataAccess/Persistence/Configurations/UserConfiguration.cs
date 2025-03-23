using HairPros.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.DataAccess.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            // Asosiy kalitni o'rnatish
            builder.HasKey(user => user.Id);

            // Email konfiguratsiyasi
            builder.Property(user => user.Email)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasIndex(user => user.Email).IsUnique(); // Email unikal bo‘lishi kerak

            // Username konfiguratsiyasi
            builder.Property(user => user.UserName)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(user => user.UserName).IsUnique(); // Username ham unikal bo‘lishi kerak

            // PasswordHash - majburiy maydon
            builder.Property(user => user.PasswordHash)
                .IsRequired();

            // PhoneNumber majburiy emas, lekin uzunligi belgilanadi
            builder.Property(user => user.PhoneNumber)
                .HasMaxLength(20)
                .IsRequired(false);

            // Dastlabki admin foydalanuvchini yaratish
            builder.HasData(GenerateAdminUser());
        }

        private IdentityUser GenerateAdminUser()
        {
            var hasher = new PasswordHasher<IdentityUser>();
            var admin = new IdentityUser
            {
                Id =  "12345678-1234-1234-1234-123456789abc",
                UserName = "Akmal_Inomjonov",
                Email = "Inomjonovakmal0320@gmail.com",
                NormalizedEmail = "INOMJONOVAKMAL0320@GMAIL.COM",
                NormalizedUserName = "AKMAL_INOMJONOV",
                PhoneNumber = "+998880146661",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                PasswordHash = "AQAAAAIAAYagAAAAEFU978DUOXg/ATh8xNta19TOu0uiugx5rXA1EIkyA7NAmnfKbUny6JHu09BnWpeM2w=="

            };
          
            return admin;
        }
    }


}
