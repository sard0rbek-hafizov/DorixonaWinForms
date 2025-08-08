namespace Dorixona.Domain.Models.AdminModel.AdminDTO;

public class AdminViewDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public string FullName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public DateTime CreatedAt { get; set; }

    // Qo‘shimcha foydalanuvchi ma'lumotlari (optional)
    public string? Role { get; set; }
    public bool IsActive { get; set; }
}
