namespace Dorixona.Domain.Models.AuthModel.Entities;

public class PasswordResetToken
{
    public Guid Id { get; set; } = Guid.NewGuid();         // Token uchun unique ID
    public Guid UserId { get; set; }                       // FK: foydalanuvchi bilan bog‘liq

    public string Token { get; set; } = default!;          // Parolni tiklash uchun yuboriladigan token
    public bool IsUsed { get; set; } = false;              // Foydalanuvchi tokenni ishlatdimi?
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Yaratilgan vaqt
    public DateTime ExpiresAt { get; set; }                // Token qachongacha amal qiladi

    // Optional: navigation property
    // public User User { get; set; } = default!;
}
