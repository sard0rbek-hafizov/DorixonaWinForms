namespace Dorixona.Domain.Models.PillsModel.PillDTO;
public class GetPillForCustomerDto
{
    public string Name { get; init; } = default!;          // Dorining nomi
    public decimal Price { get; init; }                    // Narxi
    public int StockQuantity { get; init; }                // Mavjud miqdori
    public string PharmacyName { get; init; } = default!;  // Qaysi dorixonada mavjud
}
