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
          
            builder.HasKey(user => user.Id);

         
            builder.Property(user => user.Email)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasIndex(user => user.Email).IsUnique(); 
         
            builder.Property(user => user.UserName)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(user => user.UserName).IsUnique(); 

            builder.Property(user => user.PasswordHash)
                .IsRequired();

            // PhoneNumber majburiy emas, lekin uzunligi belgilanadi
            builder.Property(user => user.PhoneNumber)
                .HasMaxLength(20)
                .IsRequired(false);

           
          
        }

       
    }


}
