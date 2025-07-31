using Dorixona.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Dorixona.Domain.Models.PatientModel.PatientDTO;

public class PatientUpdateDto
{
    [Required(ErrorMessage = "Ism majburiy.")]
    [MaxLength(50)]
    public string FirstName { get; set; } = default!;

    [Required(ErrorMessage = "Familiya majburiy.")]
    [MaxLength(50)]
    public string LastName { get; set; } = default!;

    [MaxLength(50)]
    public string? MiddleName { get; set; }

    [Phone(ErrorMessage = "Telefon raqami noto‘g‘ri.")]
    public string? PhoneNumber { get; set; }

    [MaxLength(100)]
    public string? Address { get; set; }

    [MaxLength(200)]
    public string? AllergyInfo { get; set; }

    [MaxLength(500)]
    public string? MedicalHistory { get; set; }

    [MaxLength(200)]
    public string? EmergencyContact { get; set; }

    [MaxLength(200)]
    public string? BloodType { get; set; }

    public bool HasChronicDiseases { get; set; }

    public Gender? Gender { get; set; }
}
