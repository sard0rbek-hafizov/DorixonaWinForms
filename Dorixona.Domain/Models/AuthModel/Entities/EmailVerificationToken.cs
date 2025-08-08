namespace Dorixona.Domain.Models.AuthModel.Entities;

public class EmailVerificationToken
{
    public Guid Id { get; set; } = Guid.NewGuid();        // Token uchun unique ID
    public Guid UserId { get; set; }                      // Tashqi kalit (User bilan bog‘lanadi)

    public string Token { get; set; } = default!;         // Emailga yuboriladigan tasdiqlovchi token
    public bool IsUsed { get; set; } = false;             // Token ishlatilganmi yoki yo‘q
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Yaratilgan vaqt
    public DateTime ExpiresAt { get; set; }               // Muddati tugash vaqti
}