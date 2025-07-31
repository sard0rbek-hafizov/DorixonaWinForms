using System.ComponentModel.DataAnnotations;

namespace Dorixona.Domain.Models.AdminModel.AdminDTO;

public class AdminCreateDto
{
    [Required(ErrorMessage = "UserId bo'sh bo'lishi mumkin emas.")]
    public Guid UserId { get; set; }

    [MaxLength(500, ErrorMessage = "Izoh (Notes) maksimal 500 ta belgidan oshmasligi kerak.")]
    public string? Notes { get; set; }
}
