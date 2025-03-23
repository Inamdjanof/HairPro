using HairPro.Core.Entities;
using HairPro.Shared.Services;
using HairPros.Core.Common;
using HairPros.Core.Entities;
using HairPros.Core.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HairPro.DataAccess.Persistence
{
    public class DatabaseContext : IdentityDbContext<User, ApplicationRole,Guid>
    {
        private readonly IClaimService _claimService;
        private readonly IHttpContextAccessor  _httpContextAccessor;

        public DatabaseContext(DbContextOptions options,IClaimService claimService, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _claimService = claimService;
            _httpContextAccessor = httpContextAccessor;

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public DbSet<Barber> Barbers { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BarberRating> BarberRating { get; set; }
        public DbSet<BarberService> BarberServices { get; set; }
        public DbSet<BarberShop> BarberShop { get; set; }
        public DbSet<BarberHours> BarberHours { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<OtpCode> OtpCodes { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);

            builder.Entity<ApplicationRole>().HasData(
                new ApplicationRole(Role.Admin) { Id = Guid.NewGuid() },
                new ApplicationRole(Role.Barber) { Id = Guid.NewGuid() },
                new ApplicationRole(Role.Customer) { Id = Guid.NewGuid() });
        }

        public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in ChangeTracker.Entries<IAuditedEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _claimService.GetUserId();
                        entry.Entity.CreatedOn = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = _claimService.GetUserId();
                        entry.Entity.UpdatedOn = DateTime.UtcNow;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }


}

