using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Enums;
using Dorixona.Domain.Models.PillsModel.PillEntities;
using System.ComponentModel.DataAnnotations;

namespace Dorixona.Domain.Models.PharmacyModel.Entities;

public class Pharmacy : BaseParams
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string Address { get; set; } = string.Empty;

    [Phone]
    [StringLength(15)]
    public string PhoneNumber { get; set; } = string.Empty;

    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; } = string.Empty;
    [Required]
    public bool IsConfirmed { get; set; } = false; // Admin tasdiqlaganmi

    [Required]
    public bool IsActive { get; set; } = true; // Faol aptekami

    [Required]
    public Guid OwnerId { get; set; }

    [StringLength(50)]
    public string LicenseNumber { get; set; } = string.Empty;
    public UserStatus Status { get; set; } = UserStatus.Active;

    // Navigation property (bog'liq dori ro'yxati)
    public List<Pill>? Pills { get; set; }
}
