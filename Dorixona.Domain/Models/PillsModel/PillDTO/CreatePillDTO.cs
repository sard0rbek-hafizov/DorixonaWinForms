using Dorixona.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Dorixona.Application.DTOs.Pills;

public class CreatePillDto
{
    [Required(ErrorMessage = "Dori nomi majburiy.")]
    [StringLength(100, ErrorMessage = "Dori nomi maksimal 100 ta belgidan oshmasligi kerak.")]
    public string Name { get; set; } = default!;

    [StringLength(500, ErrorMessage = "Tavsif maksimal 500 ta belgidan oshmasligi kerak.")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Ishlab chiqaruvchi nomi majburiy.")]
    [StringLength(100, ErrorMessage = "Ishlab chiqaruvchi nomi maksimal 100 ta belgidan oshmasligi kerak.")]
    public string Manufacturer { get; set; } = default!;

    [Required(ErrorMessage = "Ishlab chiqarilgan sana majburiy.")]
    [DataType(DataType.Date)]
    public DateTime ManufactureDate { get; set; }

    [Required(ErrorMessage = "Yaroqlilik muddati majburiy.")]
    [DataType(DataType.Date)]
    public DateTime ExpiryDate { get; set; }

    [Required(ErrorMessage = "Narx majburiy.")]
    [Range(0.01, 100_000, ErrorMessage = "Narx 0.01 dan katta bo'lishi kerak.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Dozalash majburiy.")]
    [StringLength(50, ErrorMessage = "Dozalash maksimal 50 ta belgidan iborat bo'lishi kerak.")]
    public string Dosage { get; set; } = default!;

    [Required(ErrorMessage = "Dorining turi tanlanishi kerak.")]
    public PillType PillType { get; set; }

    [Required(ErrorMessage = "Ombordagi soni majburiy.")]
    [Range(0, 100_000, ErrorMessage = "Ombordagi soni manfiy bo'lishi mumkin emas.")]
    public int StockQuantity { get; set; }

    [Url(ErrorMessage = "Rasm URL noto‘g‘ri formatda.")]
    public string? ImageUrl { get; set; }

    [StringLength(100, ErrorMessage = "Shtrixkod maksimal 100 belgidan iborat bo‘lishi kerak.")]
    public string? Barcode { get; set; }

    [StringLength(1000, ErrorMessage = "Ingredientlar maksimal 1000 belgidan oshmasligi kerak.")]
    public string? Ingredients { get; set; }

    public bool IsPrescriptionRequired { get; set; }

    public Guid? CategoryId { get; set; }

    [Required(ErrorMessage = "Dorixona ID majburiy.")]
    public Guid PharmacyId { get; set; }
}
