using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Enums;

namespace Dorixona.Domain.Models.AuthModel.Entities;

// Har bir foydalanuvchi login urinishlarini tarixda saqlash uchun model.
public class LoginHistory : Entity
{
    // FK: Foydalanuvchi
    public Guid UserId { get; private set; }

    // Login urinish vaqti (UTC)
    public DateTime AttemptedAt { get; private set; }

    // Login urinishining manzili (IP va qurilma)
    public string IpAddress { get; private set; } = string.Empty;
    public string Device { get; private set; } = string.Empty;

    // Login muvaffaqiyatli yoki yo‘q
    public bool IsSuccessful { get; private set; }

    // Login urinish sababi (masalan: noto‘g‘ri parol, bloklangan foydalanuvchi, muvaffaqiyatli, h.k.)
    public string? Reason { get; private set; }

    // EF Core uchun parameterless constructor
    private LoginHistory() { }

    // Konstruktor — yangi login tarixini yaratish uchun
    public LoginHistory(
        Guid userId,
        bool isSuccessful,
        string ipAddress,
        string device,
        string? reason = null)
    {
        UserId = userId;
        AttemptedAt = DateTime.UtcNow;
        IsSuccessful = isSuccessful;
        IpAddress = ipAddress;
        Device = device;
        Reason = reason;
    }
}
