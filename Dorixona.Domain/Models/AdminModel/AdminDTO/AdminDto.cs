using System.ComponentModel.DataAnnotations;

namespace Dorixona.Domain.Models.AdminModel.AdminDTO;

public class AdminDto
{
    [Required(ErrorMessage = "Admin ID majburiy.")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "To‘liq ism majburiy.")]
    [MaxLength(100, ErrorMessage = "Ism 100 belgidan oshmasligi kerak.")]
    public string FullName { get; set; } = default!;

    [Required(ErrorMessage = "Email manzil majburiy.")]
    [EmailAddress(ErrorMessage = "Email formati noto‘g‘ri.")]
    public string Email { get; set; } = default!;

    [Phone(ErrorMessage = "Telefon raqam formati noto‘g‘ri.")]
    [MaxLength(15, ErrorMessage = "Telefon raqam 15 belgidan oshmasligi kerak.")]
    public string? PhoneNumber { get; set; }

    [Required(ErrorMessage = "Foydalanuvchi roli majburiy.")]
    public string Role { get; set; } = "Admin";

    [Required(ErrorMessage = "Holat majburiy.")]
    public string Status { get; set; } = "Active";

    public DateTime CreatedAt { get; set; }
    public DateTime? LastLoginAt { get; set; }
}