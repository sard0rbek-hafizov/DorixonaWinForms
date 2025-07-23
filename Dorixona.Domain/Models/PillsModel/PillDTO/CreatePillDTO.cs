namespace Dorixona.Domain.Models.PillsModel.PillDTO;
public class CreatePillDTO
{
    public string Name { get; set; }              // Dorining nomi
    public string Description { get; set; }       // Tavsifi
    public string Manufacturer { get; set; }      // Ishlab chiqaruvchi
    public DateTime ManufactureDate { get; set; } // Ishlab chiqarilgan sana
    public DateTime ExpiryDate { get; set; }      // Yaroqlilik muddati
    public decimal Price { get; set; }            // Narxi
    public string Dosage { get; set; }            // Dozasi (masalan: 500mg)
    public string Form { get; set; }              // Shakli (sirop, tabletka, kapsula)
    public int StockQuantity { get; set; }        // Ombordagi miqdori
}
