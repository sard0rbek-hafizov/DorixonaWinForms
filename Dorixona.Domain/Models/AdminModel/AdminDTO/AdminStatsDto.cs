namespace Dorixona.Domain.Models.AdminModel.AdminDTO;

public class AdminStatsDto
{
    public int TotalAdmins { get; set; }
    public int ActiveAdmins { get; set; }
    public int InactiveAdmins { get; set; }

    public DateTime LastAdminCreatedAt { get; set; }
}
