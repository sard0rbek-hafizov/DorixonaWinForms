namespace Dorixona.Domain.Models.AdminModel.IAdminRepositories;

public interface IAdminValidator
{
    Task<bool> IsUserAlreadyAdminAsync(Guid userId);
    Task<bool> ExistsAsync(Guid adminId);
    Task<bool> IsValidForUpdateAsync(Guid adminId, Guid userId);
}
