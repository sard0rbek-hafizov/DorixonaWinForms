using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Enums;
using Dorixona.Domain.Models.PharmacyModel;
using Dorixona.Domain.Models.PharmacyModel.Entities;

namespace Dorixona.Domain.Models.PillsModel.PillEntities;

public class Pill : BaseParams
{
    public string Name { get; set; } = default!;                  // Dorining nomi
    public string? Description { get; set; }                      // Tavsifi
    public string Manufacturer { get; set; } = default!;          // Ishlab chiqaruvchi
    public DateTime ManufactureDate { get; set; }                 // Ishlab chiqarilgan sana
    public DateTime ExpiryDate { get; set; }                      // Yaroqlilik muddati
    public decimal Price { get; set; }                            // Narxi
    public string Dosage { get; set; } = default!;                // Dozasi (masalan, 500mg)
    public PillType PillType { get; set; }                        // Dori shakli
    public int StockQuantity { get; set; }                        // Ombordagi miqdori
    public string? ImageUrl { get; set; }                         // Rasm (optional)
    public string? Barcode { get; set; }                          // Unikal barkod
    public string? Ingredients { get; set; }                      // Tarkibi
    public bool IsPrescriptionRequired { get; set; } = false;     // Retsept kerakmi
    public Guid? CategoryId { get; set; }                         // Dori kategoriyasi (agar mavjud bo‘lsa)
    public Guid? PharmacyId { get; set; }                         // FK: dorixona

    //  Navigatsiya properti — EF Core uchun muhim
    public Pharmacy? Pharmacy { get; set; }
}
