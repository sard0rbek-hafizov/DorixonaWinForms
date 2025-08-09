using Microsoft.AspNetCore.Identity;

namespace Dorixona.Infrastructure.Authentication.Identity;

// Ilova foydalanuvchisi, IdentityUser<Guid> dan kengaytirilgan
public class ApplicationUser : IdentityUser<Guid>
{
    // To'liq ism
    public string FullName { get; set; } = string.Empty;

    // Rol (Identity bilan alohida boshqariladi)
    public string? Role { get; set; }

    // Profil rasmi URL manzili
    public string? ProfileImageUrl { get; set; }

    // Hisob yaratilgan sana (UTC)
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // So'nggi tizimga kirish vaqti (UTC)
    public DateTime? LastLoginAt { get; set; }

    // Hisob bloklangan oxirgi vaqt (UTC)
    public DateTime? LockoutEndUtc => LockoutEnd?.UtcDateTime;

    // Elektron pochta tasdiqlanganligi
    public bool IsEmailConfirmed => EmailConfirmed;

    // Telefon raqam tasdiqlanganligi
    public bool IsPhoneNumberConfirmed => PhoneNumberConfirmed;

    // Ikki bosqichli autentifikatsiya yoqilganligi
    public bool IsTwoFactorEnabled => TwoFactorEnabled;

    // Foydalanuvchi uchun ko'rsatiladigan ism
    public string GetDisplayName() => !string.IsNullOrWhiteSpace(FullName) ? FullName : UserName ?? Email ?? string.Empty;
}