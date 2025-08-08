using FluentValidation.Results;

namespace Dorixona.Application.Common.Exceptions;

public class ValidationException : Exception
{
    public IReadOnlyList<ValidationFailure> Failures { get; }

    public ValidationException(IEnumerable<ValidationFailure> failures)
        : base("Validation exception")
    {
        Failures = failures.ToList().AsReadOnly();
    }
}
