namespace Dorixona.Application.Abstractions;

// CQRS pattern'dagi o‘qish (read) amallari uchun marker interfeys.
public interface IQuery<out TResponse>
{
}