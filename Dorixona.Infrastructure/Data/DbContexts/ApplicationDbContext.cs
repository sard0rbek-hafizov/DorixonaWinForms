using Dorixona.Domain.Models.AdminModel.AdminEntities;
using Dorixona.Domain.Models.AuthModel.Entities;
using Dorixona.Domain.Models.OrderModel.Entities;
using Dorixona.Domain.Models.PatientModel.PatientEntities;
using Dorixona.Domain.Models.PharmacistModel.PharmacistEntities;
using Dorixona.Domain.Models.PharmacyModel.Entities;
using Dorixona.Domain.Models.PillsModel.PillEntities;
using Dorixona.Domain.Models.UserModel.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.IO;


namespace Dorixona.Infrastructure.Data.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // DbSet-lar
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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Assembly ichidan barcha konfiguratsiyalarni yuklaymiz
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Connection string appsettings.json dan keladi
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}