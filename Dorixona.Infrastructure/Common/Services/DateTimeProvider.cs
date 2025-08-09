namespace Dorixona.Infrastructure.Common.Services;


public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
    public DateTime Now => DateTime.Now;
}
public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
    DateTime Now { get; }
}