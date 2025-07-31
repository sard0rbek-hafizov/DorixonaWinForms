using System.ComponentModel.DataAnnotations;

namespace Dorixona.Domain.Models.AdminModel.AdminDTO;

public class AdminUpdateDto
{
    [Required(ErrorMessage = "Admin ID bo'sh bo'lishi mumkin emas.")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "User ID bo'sh bo'lishi mumkin emas.")]
    public Guid UserId { get; set; }

    [MaxLength(500, ErrorMessage = "Izoh (Notes) maksimal 500 ta belgidan oshmasligi kerak.")]
    public string? Notes { get; set; }
}
