using Dorixona.Domain.Enums;

namespace Dorixona.Domain.Models.PillsModel.PillDTO;

public class GetPillForAdminDto
{
    public Guid Id { get; set; }                        // Dori ID
    public string Name { get; set; } = default!;        // Dorining nomi
    public string Description { get; set; } = default!; // Tavsifi
    public string Manufacturer { get; set; } = default!;// Ishlab chiqaruvchi
    public DateTime ManufactureDate { get; set; }       // Ishlab chiqarilgan sana
    public DateTime ExpiryDate { get; set; }            // Yaroqlilik muddati
    public decimal Price { get; set; }                  // Narxi
    public string Dosage { get; set; } = default!;      // Dozasi (500mg, 100ml)
    public PillType PillType { get; set; }              // Dori shakli (Tabletka, Sirop)

    public int StockQuantity { get; set; }              // Ombordagi mavjud miqdor
    public string? ImageUrl { get; set; }               // Rasmi
    public string? Barcode { get; set; }                // Shtrix kodi
    public string? Ingredients { get; set; }            // Tarkibi (e.g. "Paracetamol, Caffeine")
    public bool IsPrescriptionRequired { get; set; }    // Reçeteli yoki yo‘q
    public string? CategoryName { get; set; }           // Kategoriya (e.g. "Og‘riq qoldiruvchi")

    public string PharmacyName { get; set; } = default!;// Qaysi dorixonaga tegishli
    public DateTime CreatedAt { get; set; }             // Yaratilgan vaqt
    public DateTime UpdatedAt { get; set; }             // Oxirgi tahrir vaqti
}
