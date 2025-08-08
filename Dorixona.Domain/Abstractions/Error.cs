namespace Dorixona.Domain.Abstractions;

public sealed record Error(string Code, string Message)
{
    public static readonly Error None = new(string.Empty, string.Empty);

    public static Error Validation(string message) =>
        new("Validation", message);

    public static Error Failure(string code, string message) =>
        new(code, message);

    public static Error NotFound(string entity, object key) =>
        new("NotFound", $"{entity} with key '{key}' was not found.");

    public static Error Conflict(string message) =>
        new("Conflict", message);

    public static Error Unauthorized(string message) =>
        new("Unauthorized", message);

    public override string ToString() => $"[{Code}] {Message}";
}
