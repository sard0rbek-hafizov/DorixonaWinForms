using Dorixona.Domain.Models.AuthModel.Entities;
using Dorixona.Domain.Models.UserModel.UserEntities;
using Dorixona.Domain.Abstractions;

namespace Dorixona.Domain.Models.AuthModel.Rules;

public class PasswordResetBusinessRules
{
    // Foydalanuvchi mavjudligini tekshiradi.
    public Task EnsureUserExists(User? user)
    {
        if (user == null)
            throw new ValidationException("Foydalanuvchi topilmadi.");

        return Task.CompletedTask;
    }

    // Parolni tiklash tokeni mavjudligini va yaroqliligini tekshiradi.
    public Task EnsureResetTokenIsValid(PasswordResetToken? token)
    {
        if (token == null)
            throw new ValidationException("Token topilmadi.");

        if (token.IsUsed)
            throw new ValidationException("Bu token allaqachon ishlatilgan.");

        if (token.ExpiresAt < DateTime.UtcNow)
            throw new ValidationException("Token muddati tugagan.");

        return Task.CompletedTask;
    }

    // Yangi parolning kuchliligini tekshiradi.
    public Task EnsureNewPasswordIsStrong(string newPassword)
    {
        if (string.IsNullOrWhiteSpace(newPassword))
            throw new ValidationException("Parol bo‘sh bo‘lishi mumkin emas.");

        if (newPassword.Length < 8)
            throw new ValidationException("Parol kamida 8 ta belgidan iborat bo‘lishi kerak.");

        if (!newPassword.Any(char.IsUpper))
            throw new ValidationException("Parolda kamida bitta katta harf bo‘lishi kerak.");

        if (!newPassword.Any(char.IsDigit))
            throw new ValidationException("Parolda kamida bitta raqam bo‘lishi kerak.");

        if (!newPassword.Any(c => char.IsSymbol(c) || char.IsPunctuation(c)))
            throw new ValidationException("Parolda kamida bitta maxsus belgi bo‘lishi kerak.");

        return Task.CompletedTask;
    }
}