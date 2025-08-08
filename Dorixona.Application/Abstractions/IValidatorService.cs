using Dorixona.Domain.Abstractions;

namespace Dorixona.Application.Abstractions;

// Har qanday DTO ni validatsiya qilish uchun servis interfeysi.
public interface IValidatorService<in T>
{
    Task<IReadOnlyList<string>> ValidateAsync(T model, CancellationToken cancellationToken = default);
}
