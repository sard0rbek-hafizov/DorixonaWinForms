using Dorixona.Domain.Enums;
using Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;

namespace Dorixona.Application.DTOs.Pills;

public class PillDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;

    public string Manufacturer { get; set; } = default!;

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public string Barcode { get; set; } = default!;

    public DateOnly ExpiryDate { get; set; }

    public PillType PillType { get; set; }

    public bool IsActive { get; set; }

    // ----- Optional Relationship fields -----

    // Dorixona haqida qisqacha info (frontend uchun qulay)
    public List<PharmacyShortDto> PharmacyShortDto { get; set; } = new();

    // Qo‘shimcha frontga qulaylik uchun (badge, color tag uchun)
    public string PillTypeName => PillType.ToString();

    public bool IsExpired => ExpiryDate < DateOnly.FromDateTime(DateTime.UtcNow);
}
