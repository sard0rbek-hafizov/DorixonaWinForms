namespace Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;

public class FilterPharmacyDto
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public bool? IsActive { get; set; } // Qo‘shish foydali bo‘ladi
}
