using System.ComponentModel.DataAnnotations;

namespace Dorixona.Domain.Models.PharmacistModel.PharmacistDTO;

public class PharmacistUpdateDto
{
    [Required(ErrorMessage = "Pharmacist ID bo‘sh bo‘lmasligi kerak.")]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "User ID majburiy.")]
    public Guid UserId { get; set; }

    [Required(ErrorMessage = "Pharmacy ID majburiy.")]
    public Guid PharmacyId { get; set; }

    [MaxLength(255, ErrorMessage = "Certification maksimal uzunligi 255 belgidan oshmasligi kerak.")]
    public string? Certification { get; set; }

    public bool IsLicensed { get; set; } = true;

    [Required(ErrorMessage = "Start date majburiy.")]
    public DateTime StartDate { get; set; } = DateTime.UtcNow;

    public bool IsActive { get; set; } = true;
}
