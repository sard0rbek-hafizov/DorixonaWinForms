using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Enums;
using System.ComponentModel.DataAnnotations;
namespace Dorixona.Domain.Models.PatientModel.PatientEntities;
public class Patient : BaseParams
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string MiddleName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Gender { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    public string PassportNumber { get; set; }
    public DateTime RegisteredAt { get; set; }
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
    public UserStatus? Status { get; set; }
    public bool? IsDeleted { get; set; }
    public string PasswordHash { get; set; }
}
