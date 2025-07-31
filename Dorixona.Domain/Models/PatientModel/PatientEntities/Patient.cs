using Dorixona.Domain.Abstractions;
using System.ComponentModel.DataAnnotations;
namespace Dorixona.Domain.Models.PatientModel.PatientEntities;
public class Patient : BaseParams
{
    [Required]
    public DateTime BirthDate { get; set; }

    [MaxLength(100)]
    public string? Address { get; set; }

    [MaxLength(200)]
    public string? AllergyInfo { get; set; }

    [MaxLength(500)]
    public string? MedicalHistory { get; set; }

    [MaxLength(200)]
    public string? EmergencyContact { get; set; }

    public bool HasChronicDiseases { get; set; } = false;

    [MaxLength(200)]
    public string? BloodType { get; set; } // Masalan: A+, B-, O+, AB+

    // Computed property for Age
    public int Age => DateTime.UtcNow.Year - BirthDate.Year;
}
