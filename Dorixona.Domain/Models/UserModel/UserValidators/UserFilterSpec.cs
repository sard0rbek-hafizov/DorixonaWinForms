using Dorixona.Domain.Enums;
using Dorixona.Domain.Models.UserModel.UserEntities;
using Dorixona.Domain.Models.UsrModel.UserDTO;
using System.Linq.Expressions;

namespace Dorixona.Domain.Models.UsrModel.UserSpecifications;
public static class UserFilterSpec
{
    public static Expression<Func<User, bool>> GetFilter(UserFilterDto dto)
    {
        return user =>
            (string.IsNullOrEmpty(dto.FullName) ||
                (user.FirstName + " " + user.LastName + " " + user.MiddleName).ToLower().Contains(dto.FullName.ToLower())) &&
            (string.IsNullOrEmpty(dto.Email) || user.Email.ToLower().Contains(dto.Email.ToLower())) &&
            (!dto.Role.HasValue || user.Role == dto.Role.Value) &&
            (!dto.Status.HasValue || user.Status == dto.Status.Value) &&
            (!dto.Gender.HasValue || user.Gender == dto.Gender.Value);
    }
}
