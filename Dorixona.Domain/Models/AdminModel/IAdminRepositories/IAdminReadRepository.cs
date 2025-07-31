using Dorixona.Domain.Models.AdminModel.AdminDTO;

namespace Dorixona.Domain.Models.AdminModel.IAdminRepositories;

public interface IAdminReadRepository
{
    Task<AdminDetailsDto?> GetDetailsByIdAsync(Guid id);
    Task<IEnumerable<AdminShortInfoDto>> GetAllShortInfoAsync();
    Task<IEnumerable<AdminDto>> GetFilteredAsync(AdminFilterDto filterDto);
    Task<IEnumerable<AdminDto>> GetPaginatedAsync(AdminPaginationDto paginationDto);
}