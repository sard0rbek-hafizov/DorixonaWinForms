using Microsoft.AspNetCore.Identity;

namespace Dorixona.Infrastructure.Authentication.Identity;

public class ApplicationRole : IdentityRole<Guid>
{
    public string? Description { get; set; }
}
