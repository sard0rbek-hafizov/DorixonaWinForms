namespace Dorixona.Domain.Models.PillsModel.PillDTO;
public class GetPillForAdminDto
{
    public Guid Id { get; set; }                  // Pill ID
    public string Name { get; set; }              // Dorining nomi
    public string Description { get; set; }       // Tavsifi
    public string Manufacturer { get; set; }      // Ishlab chiqaruvchi
    public DateTime ManufactureDate { get; set; } // Ishlab chiqarilgan sana
    public DateTime ExpiryDate { get; set; }      // Yaroqlilik muddati
    public decimal Price { get; set; }            // Narxi
    public string Dosage { get; set; }            // Dozasi (500mg va h.k.)
    public string Form { get; set; }              // Shakli (tabletkami, siropmi)
    public int StockQuantity { get; set; }        // Ombordagi miqdori
    public DateTime CreatedAt { get; set; }       // Qachon yaratilgan
    public DateTime UpdatedAt { get; set; }       // Oxirgi o‘zgartirish
}
