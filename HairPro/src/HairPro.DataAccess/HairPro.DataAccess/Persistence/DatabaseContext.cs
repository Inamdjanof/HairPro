using HairPro.Core.Entities;
using HairPros.Core.Entities;
using HairPros.Core.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HairPro.DataAccess.Persistence
{
    public class DatabaseContext : IdentityDbContext<User, ApplicationRole, Guid>
    {

        public DatabaseContext(DbContextOptions options)
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public DbSet<Barber> Barbers { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<AllService> Services { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BarberRating> BarberRating { get; set; }
        public DbSet<BarberService> BarberServices { get; set; }
        public DbSet<BarberShop> BarberShop { get; set; }
        public DbSet<BarberHours> BarberHours { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<OtpCode> OtpCodes { get; set; }
        public DbSet<BarberPortfolio> BarberPortfolios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);

            builder.Entity<ApplicationRole>().HasData(
                new ApplicationRole(UserRole.Admin) { Id = Guid.NewGuid() },
                new ApplicationRole(UserRole.Barber) { Id = Guid.NewGuid() },
                new ApplicationRole(UserRole.Customer) { Id = Guid.NewGuid() });
        }

   

    }



}

