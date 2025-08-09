using Microsoft.AspNetCore.Identity;

namespace Dorixona.Infrastructure.Authentication.Identity;
public static class UserManagerExtensions
{
    public static async Task<bool> CheckPasswordAsync(this UserManager<ApplicationUser> userManager, ApplicationUser user, string password)
    {
        if (user == null) return false;
        return await userManager.CheckPasswordAsync(user, password);
    }
}