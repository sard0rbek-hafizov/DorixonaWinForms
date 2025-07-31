using Dorixona.Domain.Models.AdminModel.AdminDTO;

namespace Dorixona.Domain.Models.AdminModel.IAdminRepositories;


public interface IAdminActivityLogRepository
{
    Task LogActivityAsync(AdminActivityLogDto logDto);
    Task<IEnumerable<AdminActivityLogDto>> GetLogsByAdminIdAsync(Guid adminId);
}
