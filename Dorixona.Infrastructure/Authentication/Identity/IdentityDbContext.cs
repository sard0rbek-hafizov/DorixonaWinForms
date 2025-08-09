using Dorixona.Infrastructure.Authentication.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dorixona.Infrastructure.Authentication.Identity
{
    // Identity uchun DbContext
    public class IdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options)
        {
        }

        // Agar kerak bo'lsa, boshqa DbSet larni shu yerda qo'shishingiz mumkin
        // public DbSet<CustomEntity> CustomEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Identity jadval nomlarini va maydonlarini sozlash (agar kerak bo‘lsa)
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable("Users");
                // Qo'shimcha konfiguratsiyalar (masalan, indekslar)
            });

            builder.Entity<ApplicationRole>(entity =>
            {
                entity.ToTable("Roles");
                // Qo'shimcha konfiguratsiyalar
            });

            builder.Entity<IdentityUserRole<Guid>>(entity =>
            {
                entity.ToTable("UserRoles");
            });

            builder.Entity<IdentityUserClaim<Guid>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            builder.Entity<IdentityUserLogin<Guid>>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            builder.Entity<IdentityRoleClaim<Guid>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });

            builder.Entity<IdentityUserToken<Guid>>(entity =>
            {
                entity.ToTable("UserTokens");
            });

            // Qo'shimcha konfiguratsiyalar kerak bo'lsa shu yerga qo'shish mumkin
        }
    }

    // Role sinfi, kerak bo'lsa qo'shimcha maydonlar qo'shish mumkin
    public class ApplicationRole : IdentityRole<Guid>
    {
        // Misol uchun: Description maydoni
        public string? Description { get; set; }
    }
}
