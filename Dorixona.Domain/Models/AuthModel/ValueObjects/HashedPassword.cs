using System.Security.Cryptography;
using System.Text;

namespace Dorixona.Domain.Models.AuthModel.ValueObjects;

public sealed class HashedPassword : IEquatable<HashedPassword>
{
    public string Value { get; }

    private HashedPassword(string value)
    {
        Value = value;
    }

    public static HashedPassword FromPlainText(string plainPassword)
    {
        if (string.IsNullOrWhiteSpace(plainPassword))
            throw new ArgumentException("Password cannot be empty.");

        // Hashlash (masalan: SHA256)
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(plainPassword);
        var hashBytes = sha256.ComputeHash(bytes);
        var hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();

        return new HashedPassword(hash);
    }

    public static HashedPassword FromHashed(string hashedValue)
    {
        if (string.IsNullOrWhiteSpace(hashedValue))
            throw new ArgumentException("Hashed password cannot be empty.");

        return new HashedPassword(hashedValue.Trim());
    }

    public bool Equals(HashedPassword? other)
    {
        if (other is null) return false;
        return Value == other.Value;
    }

    public override bool Equals(object? obj) => Equals(obj as HashedPassword);

    public override int GetHashCode() => Value.GetHashCode();

    public override string ToString() => Value;

    public static bool operator ==(HashedPassword left, HashedPassword right) => Equals(left, right);
    public static bool operator !=(HashedPassword left, HashedPassword right) => !Equals(left, right);
}
