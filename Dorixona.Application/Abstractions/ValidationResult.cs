namespace Dorixona.Application.Abstractions;

public sealed class ValidationResult
{
    public bool IsValid { get; }
    public IReadOnlyList<string> Errors { get; }

    private ValidationResult(bool isValid, IEnumerable<string>? errors = null)
    {
        IsValid = isValid;
        Errors = (errors ?? Enumerable.Empty<string>()).ToList().AsReadOnly();
    }

    public static ValidationResult Success()
        => new ValidationResult(true);

    public static ValidationResult Fail(params string[] errors)
        => new ValidationResult(false, errors);

    public static ValidationResult Fail(IEnumerable<string> errors)
        => new ValidationResult(false, errors);
}
