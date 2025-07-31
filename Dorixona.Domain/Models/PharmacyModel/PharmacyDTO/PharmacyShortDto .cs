namespace Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;
public class PharmacyShortDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
}
