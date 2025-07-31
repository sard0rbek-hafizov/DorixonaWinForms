using System.ComponentModel.DataAnnotations;

namespace Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;

public class CreatePharmacyDto
{
    [Required(ErrorMessage = "Dorixona nomi majburiy.")]
    [StringLength(100, ErrorMessage = "Dorixona nomi 100 ta belgidan oshmasligi kerak.")]
    public string Name { get; set; } = default!;

    [Required(ErrorMessage = "Manzil majburiy.")]
    [StringLength(200, ErrorMessage = "Manzil 200 ta belgidan oshmasligi kerak.")]
    public string Address { get; set; } = default!;

    [Required(ErrorMessage = "Telefon raqam majburiy.")]
    [Phone(ErrorMessage = "Telefon raqam noto‘g‘ri formatda.")]
    public string PhoneNumber { get; set; } = default!;

    [Required(ErrorMessage = "Email majburiy.")]
    [EmailAddress(ErrorMessage = "Email noto‘g‘ri formatda.")]
    public string Email { get; set; } = default!;

    [Required(ErrorMessage = "Litsenziya raqami majburiy.")]
    [StringLength(50, ErrorMessage = "Litsenziya raqami 50 ta belgidan oshmasligi kerak.")]
    public string LicenseNumber { get; set; } = default!;

    [Required(ErrorMessage = "Ish vaqti majburiy.")]
    public string WorkingHours { get; set; } = default!;

    [Required(ErrorMessage = "24 soat ishlash holati majburiy.")]
    public bool IsOpen24Hours { get; set; }

    [Range(-90, 90, ErrorMessage = "Latitude -90 dan +90 gacha bo‘lishi kerak.")]
    public double Latitude { get; set; }

    [Range(-180, 180, ErrorMessage = "Longitude -180 dan +180 gacha bo‘lishi kerak.")]
    public double Longitude { get; set; }

    [Required(ErrorMessage = "Dorixona holati (tasdiqlanganmi) majburiy.")]
    public bool IsConfirmed { get; set; } = false;

    [Required(ErrorMessage = "Dorixona faol holati majburiy.")]
    public bool IsActive { get; set; } = true;
}
