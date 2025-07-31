using System.ComponentModel.DataAnnotations;

namespace Dorixona.Domain.Models.PharmacistModel.PharmacistDTO;

public class PharmacistCreateDto
{
    [Required(ErrorMessage = "UserId is required.")]
    public Guid UserId { get; set; }

    [Required(ErrorMessage = "PharmacyId is required.")]
    public Guid PharmacyId { get; set; }

    [MaxLength(255, ErrorMessage = "Certification must be less than 255 characters.")]
    public string? Certification { get; set; }

    public bool IsLicensed { get; set; } = true;

    [Required(ErrorMessage = "StartDate is required.")]
    public DateTime StartDate { get; set; } = DateTime.UtcNow;

    public bool IsActive { get; set; } = true;
}
