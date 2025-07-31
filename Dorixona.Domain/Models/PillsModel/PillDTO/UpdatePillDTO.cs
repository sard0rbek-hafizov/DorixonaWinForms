using Dorixona.Domain.Enums;
using Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;
using System.ComponentModel.DataAnnotations;

namespace Dorixona.Application.DTOs.Pills;

public class UpdatePillDto
{
    [Required]
    public Guid Id { get; set; }

    [Required, StringLength(100)]
    public string Name { get; set; } = default!;

    [StringLength(500)]
    public string? Description { get; set; }

    [Required, StringLength(100)]
    public string Manufacturer { get; set; } = default!;

    [Required]
    public DateTime ManufactureDate { get; set; }

    [Required]
    public DateTime ExpiryDate { get; set; }

    [Required, Range(0.01, 100000)]
    public decimal Price { get; set; }

    [Required, StringLength(50)]
    public string Dosage { get; set; } = default!;

    [Required]
    public PillType PillType { get; set; }

    [Required, Range(0, 100000)]
    public int StockQuantity { get; set; }

    public string? ImageUrl { get; set; }
    public string? Barcode { get; set; }
    public string? Ingredients { get; set; }
    public bool IsPrescriptionRequired { get; set; }
    public Guid? CategoryId { get; set; }

    // Avval: public Guid PharmacyId { get; set; }
    [Required]
    public PharmacyDto Pharmacy { get; set; } = default!;
}
