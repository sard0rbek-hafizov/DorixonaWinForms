using System.ComponentModel.DataAnnotations;

namespace Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;

public class UpdatePharmacyDto
{
    [Required(ErrorMessage = "ID majburiy.")]
    public Guid Id { get; set; }

    [StringLength(100, ErrorMessage = "Dorixona nomi 100 ta belgidan oshmasligi kerak.")]
    public string? Name { get; set; }

    [StringLength(200, ErrorMessage = "Manzil 200 ta belgidan oshmasligi kerak.")]
    public string? Address { get; set; }

    [Phone(ErrorMessage = "Telefon raqam noto‘g‘ri formatda.")]
    public string? PhoneNumber { get; set; }

    [EmailAddress(ErrorMessage = "Email noto‘g‘ri formatda.")]
    public string? Email { get; set; }

    [StringLength(50, ErrorMessage = "Litsenziya raqami 50 ta belgidan oshmasligi kerak.")]
    public string? LicenseNumber { get; set; }


    [StringLength(100, ErrorMessage = "Ish vaqti 100 ta belgidan oshmasligi kerak.")]
    public string? WorkingHours { get; set; }

    public bool? IsOpen24Hours { get; set; }

    [Range(-90, 90, ErrorMessage = "Latitude -90 dan +90 gacha bo'lishi kerak.")]
    public double? Latitude { get; set; }

    [Range(-180, 180, ErrorMessage = "Longitude -180 dan +180 gacha bo'lishi kerak.")]
    public double? Longitude { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsConfirmed { get; set; }
}
