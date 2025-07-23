using Dorixona.Domain.Abstractions;
using System.ComponentModel.DataAnnotations;
namespace Dorixona.Domain.Models.PillsModel;
public class Pill : BaseParams
{
    [Required]
    public string Name { get; set; } // Dorining nomi
    [Required]
    public string Description { get; set; } // Tavsifi
    [Required]
    public string Manufacturer { get; set; } // Ishlab chiqaruvchi
    [Required]
    public DateTime ManufactureDate { get; set; } // Ishlab chiqarilgan sanasi
    [Required]
    public DateTime ExpiryDate { get; set; } // Yaroqlilik muddati
    [Required]
    public decimal Price { get; set; } // Narxi
    [Required]
    public string Dosage { get; set; } // Dozasi (masalan: 500mg)
    [Required]
    public string Form { get; set; } // Shakli (tabletkami, siropmi)
    [Required]
    public int StockQuantity { get; set; } // Ombordagi miqdori
}
