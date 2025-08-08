namespace Dorixona.Application.Abstractions;

// CQRS pattern'dagi yozuv (write) amallari uchun marker interfeys.
public interface ICommand<out TResponse>
{
}
