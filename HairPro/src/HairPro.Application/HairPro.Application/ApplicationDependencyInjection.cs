using HairPro.Application.Common.Email;
using HairPro.Application.MappingProfiles;
using HairPro.Application.Services.Auth;
using HairPro.Application.Services.Auth.Interfaces;
using HairPro.DataAccess.Persistence;
using HairPro.Shared.Services.Impl;
using HairPro.Shared.Services;
using HairPros.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HairPro.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HairPro.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
       
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.RegisterAutoMapper();
            services.AddScoped<IOtpService,OtpService>();
            services.AddScoped<ICustomEmailSender, EmailSender>();
            services.AddScoped<IJwtTokenService, JwtTokenService>();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddIdentityServices();
            services.AddScoped<RoleManager<ApplicationRole>>();
          
          


            return services;
        }


        private static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(IMappingProfilesMarker).Assembly);
        }

        private static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole<Guid>>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireUppercase = true;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<DatabaseContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<IRoleStore<ApplicationRole>, RoleStore<ApplicationRole, DatabaseContext, Guid>>();

            services.AddScoped<UserManager<User>>();
            services.AddScoped<RoleManager<ApplicationRole>>();
            services.AddScoped<SignInManager<User>>();

            return services;
        }

    }
}
