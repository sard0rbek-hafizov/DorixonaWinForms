using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Dorixona.Infrastructure.Authentication.Identity;

public class IdentityInitializer
{
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ILogger<IdentityInitializer> _logger;

    public IdentityInitializer(
        RoleManager<ApplicationRole> roleManager,
        UserManager<ApplicationUser> userManager,
        ILogger<IdentityInitializer> logger)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _logger = logger;
    }

    public async Task InitializeAsync()
    {
        await SeedRolesAsync();
        await SeedAdminUserAsync();
    }

    private async Task SeedRolesAsync()
    {
        string[] roles = new[] { "Admin", "Patient", "Pharmacist", "Pharmacy" };

        foreach (var roleName in roles)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                var role = new ApplicationRole { Name = roleName };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                    _logger.LogInformation($"Role '{roleName}' created successfully.");
                else
                    _logger.LogError($"Failed to create role '{roleName}': {string.Join(", ", result.Errors)}");
            }
        }
    }

    private async Task SeedAdminUserAsync()
    {
        string adminEmail = "admin@dorixona.uz";
        var adminUser = await _userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            adminUser = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true,
            };

            var createResult = await _userManager.CreateAsync(adminUser, "StrongAdminPassword123!");
            if (createResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(adminUser, "Admin");
                _logger.LogInformation("Admin user created successfully.");
            }
            else
            {
                _logger.LogError($"Failed to create admin user: {string.Join(", ", createResult.Errors)}");
            }
        }
    }
}
