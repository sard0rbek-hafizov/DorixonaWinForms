using Dorixona.Domain.Enums;

namespace Dorixona.Domain.Models.PharmacistModel.PharmacistDTO;

public class PharmacistDto
{
    public Guid Id { get; set; }

    // User ma’lumotlari
    public Guid UserId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public UserStatus Status { get; set; }

    // Pharmacy bilan bog‘liq
    public Guid PharmacyId { get; set; }
    public string PharmacyName { get; set; } = string.Empty;
    public string PharmacyAddress { get; set; } = string.Empty;

    // Pharmacistga oid maxsus ma’lumotlar
    public string? Certification { get; set; }
    public bool IsLicensed { get; set; }
    public DateTime StartDate { get; set; }
    public bool IsActive { get; set; }
}
