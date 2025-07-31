using System.ComponentModel.DataAnnotations;

namespace Dorixona.Domain.Models.AdminModel.AdminDTO;

public class AdminActivityLogDto
{
    [Required(ErrorMessage = "Admin ID bo'sh bo'lishi mumkin emas.")]
    public Guid AdminId { get; set; }

    [Required(ErrorMessage = "Harakat turi bo'sh bo'lishi mumkin emas.")]
    [MaxLength(100, ErrorMessage = "Harakat turi maksimal 100 ta belgidan oshmasligi kerak.")]
    public string ActionType { get; set; } = string.Empty;

    [MaxLength(500, ErrorMessage = "Izoh maksimal 500 ta belgidan oshmasligi kerak.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Vaqt belgilanmagan.")]
    public DateTime PerformedAt { get; set; } = DateTime.UtcNow;

    [MaxLength(50)]
    public string? PerformedBy { get; set; }  // foydalanuvchi nomi yoki email (optional)
}

