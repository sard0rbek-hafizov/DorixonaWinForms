using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.AdminModel.AdminDTO;

namespace Dorixona.Application.Services.Admins;

public interface IAdminService
{
    Task<IEnumerable<AdminDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<AdminDto?> GetByIdAsync(Guid adminId, CancellationToken cancellationToken = default);
    Task<Result<AdminDto>> CreateAsync(AdminCreateDto dto, CancellationToken cancellationToken = default);
    Task<Result<AdminDto>> UpdateAsync(Guid adminId, AdminUpdateDto dto, CancellationToken cancellationToken = default);
    Task<Result> DeleteAsync(Guid adminId, CancellationToken cancellationToken = default);
}