using HairPro.Core.Entities;
using HairPro.DataAccess.Persistence;
using HairPros.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;


namespace HairPro.DataAccess
{
    public static class DataAccessDependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);
           // services.AddIdentityServices();
            return services;
        }

        private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            
            var databaseConfig = configuration
                .GetSection("Database")
                .Get<DatabaseConfiguration>() ?? new DatabaseConfiguration();

            services.AddDbContext<DatabaseContext>(options =>
            {
                if (databaseConfig.UseInMemoryDatabase)
                {
                    options.UseInMemoryDatabase("TestDb"); // Test uchun In-Memory DB
                }
                else
                {
                    if (string.IsNullOrEmpty(databaseConfig.ConnectionString))
                    {
                        throw new InvalidOperationException("Database connection string is missing.");
                    }

                    options.UseNpgsql(
                        databaseConfig.ConnectionString,
                        opt => opt.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)
                    );
                }
            });
        }


       
    }

    // ✅ Database konfiguratsiyasi modeli
    public class DatabaseConfiguration
    {
        public bool UseInMemoryDatabase { get; set; } = false;
        public string ConnectionString { get; set; } = string.Empty; // ✅ Default qiymat qo‘shildi
    }
}
