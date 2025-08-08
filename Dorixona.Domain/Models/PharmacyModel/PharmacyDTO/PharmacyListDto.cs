namespace Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;

public class PharmacyListDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
