using System.ComponentModel.DataAnnotations;

namespace Dorixona.Domain.Models.AdminModel.AdminDTO;

public class AdminSummaryDto
{
    [Required]
    [Range(0, int.MaxValue)]
    public int TotalAdmins { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int ActiveAdmins { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int BlockedAdmins { get; set; }

    [Required]
    public AdminShortInfoDto? LastCreatedAdmin { get; set; }
}
