namespace Dorixona.Domain.Models.PillsModel.PillDTO;
public class UpdatePillDTO
{
    public Guid Id { get; set; }                  // Qaysi dorini yangilamoqchisiz
    public string Name { get; set; }
    public string Description { get; set; }
    public string Manufacturer { get; set; }
    public DateTime ManufactureDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public decimal Price { get; set; }
    public string Dosage { get; set; }
    public string Form { get; set; }
    public int StockQuantity { get; set; }
}
