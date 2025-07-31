using Dorixona.Domain.Enums;

namespace Dorixona.Domain.Models.PillsModel.PillDTO;

public class FilterPillDto
{
    public string? Name { get; set; }                       // "Paracetamol", "Ibuprofen"
    public string? Manufacturer { get; set; }               // "Berlin-Chemie", "UzPharm"
    public string? Search { get; set; }
    public decimal? MinPrice { get; set; }                  // Narx: minimal
    public decimal? MaxPrice { get; set; }                  // Narx: maksimal

    public PillType? PillType { get; set; }                 // "Tabletka", "Sirop", "Kapsula"

    public DateTime? MinExpiryDate { get; set; }            // Yaroqlilik muddati: eng erta
    public DateTime? MaxExpiryDate { get; set; }            // Yaroqlilik muddati: eng kech

    public string? Dosage { get; set; }                     // "500mg", "100ml"

    public int? MinStockQuantity { get; set; }              // Ombor miqdori: minimal
    public int? MaxStockQuantity { get; set; }              // Ombor miqdori: maksimal

    public Guid? PharmacyId { get; set; }                   // Qaysi aptekaga tegishli

    // Qo‘shimcha imkoniyatlar:
    public bool? IsPrescriptionRequired { get; set; }       // Reçeta bilanmi yo‘qmi
    public Guid? CategoryId { get; set; }                   // Kategoriyaga bog‘liq holda filter
}
