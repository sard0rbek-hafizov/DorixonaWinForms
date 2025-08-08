using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.UsrModel.UserDTO;

namespace Dorixona.Application.Services.Users;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task<UserDto?> GetByIdAsync(Guid id);
    Task<Result<UserDto>> CreateAsync(UserCreateDto dto);
    Task<Result<UserDto>> UpdateAsync(Guid id, UserUpdateDto dto);
    Task<Result> DeleteAsync(Guid id);
}
