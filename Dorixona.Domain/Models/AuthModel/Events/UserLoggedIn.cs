namespace Dorixona.Domain.Models.AuthModel.Events;

public class UserLoggedIn
{
    public Guid Id { get; private set; }                     // Unikal identifikator
    public Guid UserId { get; private set; }                 // Foydalanuvchi ID (FK)
    public string IpAddress { get; private set; }            // Kirish IP manzili
    public string UserAgent { get; private set; }            // Brauzer yoki qurilma haqida ma'lumot
    public string Location { get; private set; }             // Geolokatsiya (ixtiyoriy)
    public DateTime LoggedInAt { get; private set; }         // Kirgan vaqti
    public bool IsSuccessful { get; private set; }           // Kirish muvaffaqiyatli bo'lganmi
    public string FailureReason { get; private set; }        // Muvaffaqiyatsiz bo'lsa, sabab

    // EF Core uchun bo‘sh konstruktor
    private UserLoggedIn() { }

    // Konstruktor — faqat to‘g‘ri holatda obyekt yaratiladi
    public UserLoggedIn(Guid userId, string ipAddress, string userAgent, bool isSuccessful, string? failureReason = null, string? location = null)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        IpAddress = ipAddress;
        UserAgent = userAgent;
        LoggedInAt = DateTime.UtcNow;
        IsSuccessful = isSuccessful;
        FailureReason = isSuccessful ? null : failureReason;
        Location = location;
    }
}
