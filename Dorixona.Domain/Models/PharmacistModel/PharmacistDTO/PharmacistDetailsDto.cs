using Dorixona.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Dorixona.Domain.Models.PharmacistModel.PharmacistDTO;

public class PharmacistDetailsDto
{
    public Guid Id { get; set; }

    [Required]
    public Guid UserId { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public Gender? Gender { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Role { get; set; } = "Pharmacist";

    [Required]
    public Guid PharmacyId { get; set; }

    public string? PharmacyName { get; set; }

    public string? Certification { get; set; }

    public bool IsLicensed { get; set; }

    public DateTime StartDate { get; set; }

    public bool IsActive { get; set; }

    // Count of pills this pharmacist manages
    public int PillCount { get; set; }

    // Count of patients served by this pharmacist
    public int PatientCount { get; set; }

    // Optional: List of short pill info
    public List<PillSummaryDto>? Pills { get; set; }

    // Optional: List of short patient info
    public List<PatientSummaryDto>? Patients { get; set; }
}

// Optional summary DTOs to avoid overfetching full nested entities
public class PillSummaryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class PatientSummaryDto
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
}
