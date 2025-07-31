using Dorixona.Domain.Models.AdminModel.AdminDTO;
using Dorixona.Domain.Models.AdminModel.AdminEntities;

namespace Dorixona.Domain.Models.AdminModel.IAdminRepositories;

public interface IAdminMapper
{
    Admin MapFromCreateDto(AdminCreateDto dto);
    void MapFromUpdateDto(Admin admin, AdminUpdateDto dto);
    AdminDto MapToDto(Admin admin);
}
