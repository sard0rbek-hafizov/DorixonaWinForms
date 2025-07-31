using Dorixona.Domain.Models.AdminModel.AdminDTO;

namespace Dorixona.Domain.Models.AdminModel.IAdminRepositories;

public interface IAdminDashboardRepository
{
    Task<AdminDashboardStatsDto> GetStatsAsync();
    Task<AdminSummaryDto> GetSummaryAsync();
}
