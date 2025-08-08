using Dorixona.Domain.Models.AdminModel.AdminDTO;

namespace Dorixona.Domain.Models.AdminModel.IAdminRepositories;

public interface IAdminQueryService
{
    Task<AdminViewDto?> GetByIdWithUserAsync(Guid adminId);
    Task<List<AdminViewDto>> GetAllAsync();
    Task<List<AdminViewDto>> FilterAsync(string? name, string? email);
    Task<AdminStatsDto> GetStatisticsAsync();
}
