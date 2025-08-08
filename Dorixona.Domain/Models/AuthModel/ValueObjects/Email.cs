using System.Text.RegularExpressions;

namespace Dorixona.Domain.Models.AuthModel.ValueObjects;

public sealed class Email : IEquatable<Email>
{
    private static readonly Regex _emailRegex = new(
        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
        RegexOptions.Compiled | RegexOptions.IgnoreCase);

    public string Value { get; }

    private Email(string value)
    {
        Value = value;
    }

    public static Email Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email must not be empty.", nameof(value));

        if (!_emailRegex.IsMatch(value))
            throw new ArgumentException("Invalid email format.", nameof(value));

        return new Email(value.Trim());
    }

    // Value Object equality
    public bool Equals(Email? other)
    {
        if (other is null) return false;
        return string.Equals(Value, other.Value, StringComparison.OrdinalIgnoreCase);
    }

    public override bool Equals(object? obj) => Equals(obj as Email);

    public override int GetHashCode() => Value.ToLowerInvariant().GetHashCode();

    public override string ToString() => Value;

    // Operator overloads
    public static bool operator ==(Email left, Email right) => Equals(left, right);
    public static bool operator !=(Email left, Email right) => !Equals(left, right);
}
