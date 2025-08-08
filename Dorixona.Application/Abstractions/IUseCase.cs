namespace Dorixona.Application.Abstractions;

// Har qanday use-case uchun asos interfeys.
public interface IUseCase<in TRequest, TResponse>
{
    Task<TResponse> HandleAsync(TRequest request, CancellationToken cancellationToken = default);
}