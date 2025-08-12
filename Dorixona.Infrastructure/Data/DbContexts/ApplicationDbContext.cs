using System;
using System.IO;
using Dorixona.Domain.Models.AdminModel.AdminEntities;
using Dorixona.Domain.Models.AuthModel.Entities;
using Dorixona.Domain.Models.OrderModel.Entities;
using Dorixona.Domain.Models.PatientModel.PatientEntities;
using Dorixona.Domain.Models.PharmacistModel.PharmacistEntities;
using Dorixona.Domain.Models.PharmacyModel.Entities;
using Dorixona.Domain.Models.PillsModel.PillEntities;
using Dorixona.Domain.Models.UserModel.UserEntities;
using Dorixona.Infrastructure.Authentication.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Dorixona.Infrastructure.Data.DbContexts
{
    public class ApplicationDbContext
        : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Domain DbSet-lar
        public DbSet<User> Users => Set<User>();
        public DbSet<Admin> Admins => Set<Admin>();
        public DbSet<AdminActivityLog> AdminActivityLogs => Set<AdminActivityLog>();
        public DbSet<AuthToken> AuthTokens => Set<AuthToken>();
        public DbSet<EmailVerificationToken> EmailVerificationTokens => Set<EmailVerificationToken>();
        public DbSet<LoginHistory> LoginHistories => Set<LoginHistory>();
        public DbSet<PasswordResetToken> PasswordResetTokens => Set<PasswordResetToken>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Pharmacist> Pharmacists => Set<Pharmacist>();
        public DbSet<Pharmacy> Pharmacies => Set<Pharmacy>();
        public DbSet<Pill> Pills => Set<Pill>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Identity jadval nomlarini sozlash
            builder.Entity<ApplicationUser>(entity => entity.ToTable("IdentityUsers"));
            builder.Entity<ApplicationRole>(entity => entity.ToTable("Roles"));
            builder.Entity<IdentityUserRole<Guid>>(entity => entity.ToTable("UserRoles"));
            builder.Entity<IdentityUserClaim<Guid>>(entity => entity.ToTable("UserClaims"));
            builder.Entity<IdentityUserLogin<Guid>>(entity => entity.ToTable("UserLogins"));
            builder.Entity<IdentityRoleClaim<Guid>>(entity => entity.ToTable("RoleClaims"));
            builder.Entity<IdentityUserToken<Guid>>(entity => entity.ToTable("UserTokens"));

            // Domain konfiguratsiyalarini avtomatik yuklash
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                var connectionString = config.GetConnectionString("DefaultConnection");

                optionsBuilder.UseNpgsql(connectionString);
            }
        }
    }

    // Role class (Identity uchun)
    public class ApplicationRole : IdentityRole<Guid>
    {
        public string? Description { get; set; }
    }
}
