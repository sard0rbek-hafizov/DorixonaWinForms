namespace Dorixona.Domain.Models.AdminModel.IAdminRepositories;

public interface IAdminUserAccessService
{
    Task<bool> CanAccessUser(Guid adminId, Guid userId);
}
