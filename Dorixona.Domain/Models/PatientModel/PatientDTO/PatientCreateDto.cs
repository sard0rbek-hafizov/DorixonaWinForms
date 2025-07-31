using Dorixona.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Dorixona.Domain.Models.PatientModel.PatientDTO;

public class PatientCreateDto
{
    [Required(ErrorMessage = "Ism majburiy.")]
    [MaxLength(50, ErrorMessage = "Ism maksimal 50 ta belgidan iborat bo'lishi kerak.")]
    public string FirstName { get; set; } = default!;

    [Required(ErrorMessage = "Familiya majburiy.")]
    [MaxLength(50, ErrorMessage = "Familiya maksimal 50 ta belgidan iborat bo'lishi kerak.")]
    public string LastName { get; set; } = default!;

    [MaxLength(50)]
    public string? MiddleName { get; set; }

    [Required(ErrorMessage = "Email majburiy.")]
    [EmailAddress(ErrorMessage = "Email noto‘g‘ri formatda.")]
    public string Email { get; set; } = default!;

    [Required(ErrorMessage = "Parol majburiy.")]
    [MinLength(6, ErrorMessage = "Parol kamida 6 ta belgidan iborat bo'lishi kerak.")]
    public string Password { get; set; } = default!;

    [Required(ErrorMessage = "Tug‘ilgan sana majburiy.")]
    [DataType(DataType.Date)]
    public DateTime BirthDate { get; set; }

    [Phone(ErrorMessage = "Telefon raqami noto‘g‘ri formatda.")]
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
