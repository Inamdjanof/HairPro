using HairPro.Core.Entities;
using HairPros.Core.Entities;
using HairPros.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairPro.DataAccess.Persistence
{

    public class RoleSeeder
    {
        public static async Task SeedAdminUserAsync(UserManager<User> userManager, RoleManager<ApplicationRole> roleManager)
        {
            string adminRole = Role.Admin.ToString();  
            string adminEmail = "adminhairpro@gmail.com";
            string adminUsername = "adminHairPro";
            string adminPassword = "AdminHairPro_2001";  

            // 🟢 Admin rolini yaratamiz, agar mavjud bo‘lmasa
            if (!await roleManager.RoleExistsAsync(adminRole))
            {
                await roleManager.CreateAsync(new ApplicationRole { Name = adminRole });
            }

            // 🟢 Admin foydalanuvchisini yaratamiz, agar u mavjud bo‘lmasa
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var admin = new User
                {
                    UserName = adminUsername,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, adminRole);
                }
            }
        }
    }


}
