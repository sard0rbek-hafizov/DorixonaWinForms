namespace Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;

public class PharmacyDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string LicenseNumber { get; set; } = default!;
    public bool IsActive { get; set; }
    public bool IsConfirmed { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; } // Yangi qo‘shish
}
