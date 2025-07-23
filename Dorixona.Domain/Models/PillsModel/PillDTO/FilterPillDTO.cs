namespace Dorixona.Domain.Models.PillsModel.PillDTO;
public class FilterPillDTO
{
    public string? Name { get; set; }                // "Paracetamol", "Ibuprofen" kabi
    public string? Manufacturer { get; set; }        // "Berlin-Chemie", "UzPharm"
    public decimal? MinPrice { get; set; }           // Eng kam narx
    public decimal? MaxPrice { get; set; }           // Eng katta narx
    public string? Form { get; set; }                // "Tabletka", "Sirop", "Kapsula"
    public DateTime? MinExpiryDate { get; set; }     // Eng erta yaroqlilik muddati
    public DateTime? MaxExpiryDate { get; set; }     // Eng kech yaroqlilik muddati
    public string? Dosage { get; set; }              // "500mg", "100ml"
    public int? MinStockQuantity { get; set; }       // Ombordagi kamida qancha bo‘lsin
    public int? MaxStockQuantity { get; set; }       // Ombordagi eng ko‘pi

}
