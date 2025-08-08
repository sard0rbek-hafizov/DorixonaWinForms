namespace Dorixona.Application.Abstractions;

// DTO va Entity modellar orasida mapping qilish uchun umumiy servis interfeysi.
public interface IMapperService
{
    TDestination Map<TSource, TDestination>(TSource source);
}
