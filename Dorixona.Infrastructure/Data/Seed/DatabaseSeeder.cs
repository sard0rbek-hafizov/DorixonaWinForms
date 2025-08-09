using Microsoft.EntityFrameworkCore;
using Dorixona.Domain.Enums;
using Dorixona.Domain.Models.UserModel.UserEntities;
using Dorixona.Infrastructure.Data.DbContexts;

namespace Dorixona.Infrastructure.Data.Seed;

public static class DatabaseSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        if (!await context.Users.AnyAsync())
        {
            var admin = new User(
                firstName: "System",
                lastName: "Administrator",
                middleName: null,
                email: "admin@dorixona.uz",
                password: "Admin@123", // BCrypt orqali hash qilinadi konstruktor ichida
                phoneNumber: "+998900000000"
            )
            {
                Role = Role.Admin,
                Status = UserStatus.Active,
                IsEmailConfirmed = true
            };

            await context.Users.AddAsync(admin);
            await context.SaveChangesAsync();
        }
    }
}
