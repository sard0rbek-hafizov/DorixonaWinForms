using Dorixona.Domain.Enums;
namespace Dorixona.Application.DTOs.Pharmacies;
public class ExportPharmacyDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public string Address { get; set; } = default!;

    public string PhoneNumber { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string ManagerFullName { get; set; } = default!;

    public string WorkingHours { get; set; } = default!;

    public string Description { get; set; } = default!;

    public UserStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
