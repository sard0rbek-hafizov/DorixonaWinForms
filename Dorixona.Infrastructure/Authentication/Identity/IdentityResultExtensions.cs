using Microsoft.AspNetCore.Identity;

namespace Dorixona.Infrastructure.Authentication.Identity;
public static class IdentityResultExtensions
{
    public static IEnumerable<string> GetErrors(this IdentityResult result)
    {
        return result.Errors.Select(e => e.Description);
    }
}