using Dorixona.Domain.Enums;

namespace Dorixona.Domain.Models.PatientModel.PatientDTO;

public class PatientDto
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string? MiddleName { get; set; }

    public string FullName => $"{FirstName} {LastName} {MiddleName}";

    public string Email { get; set; } = default!;
    public string? PhoneNumber { get; set; }

    public DateTime BirthDate { get; set; }
    public string? Address { get; set; }
    public string? AllergyInfo { get; set; }
    public string? MedicalHistory { get; set; }
    public string? EmergencyContact { get; set; }
    public string? BloodType { get; set; }
    public bool HasChronicDiseases { get; set; }

    public Gender? Gender { get; set; }
    public string? ProfileImageUrl { get; set; }

    public DateTime RegisteredAt { get; set; }
}
