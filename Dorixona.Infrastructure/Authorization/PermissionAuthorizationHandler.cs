using Microsoft.AspNetCore.Authorization;

namespace Dorixona.Infrastructure.Authorization;

// Permission talab qiluvchi authorization requirement
public class PermissionRequirement : IAuthorizationRequirement
{
    public string PermissionName { get; }

    public PermissionRequirement(string permissionName)
    {
        PermissionName = permissionName;
    }
}

// PermissionAuthorizationHandler - PermissionRequirement tekshiruvchi handler
public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        // Foydalanuvchi claimlari orasida kerakli permission borligini tekshiramiz
        if (context.User.HasClaim(c =>
            c.Type == "Permission" && c.Value == requirement.PermissionName))
        {
            context.Succeed(requirement);
        }
        else
        {
            // Kerakli ruxsat mavjud emas, shuning uchun nothing to do, failed hisoblanadi
        }

        return Task.CompletedTask;
    }
}