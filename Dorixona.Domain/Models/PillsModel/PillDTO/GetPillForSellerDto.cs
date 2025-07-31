namespace Dorixona.Domain.Models.PillsModel.PillDTO;
public class GetPillForSellerDto
{
    public string Name { get; init; } = default!;                 // Dorining nomi
    public string? Description { get; init; }                     // Qo‘shimcha tavsifi
    public string CategoryName { get; init; } = default!;         // Kategoriya (masalan: antibiotik)
    public decimal Price { get; init; }                           // Narxi (so‘mda)
    public int StockQuantity { get; init; }                       // Omborda nechta bor
}
