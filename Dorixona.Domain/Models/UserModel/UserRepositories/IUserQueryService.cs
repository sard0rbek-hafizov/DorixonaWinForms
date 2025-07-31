using Dorixona.Domain.Enums;
using Dorixona.Domain.Models.UsrModel.UserResponses;
namespace Dorixona.Domain.Models.UserModel.UserRepositories;

public interface IUserQueryService
{
    Task<UserResponse?> GetByIdAsync(Guid id);
    Task<UserResponse?> GetByEmailAsync(string email);
    Task<List<UserResponse>> GetAllAsync(int pageNumber, int pageSize);
    Task<List<UserResponse>> GetFilteredAsync(string? fullName, string? email, Role? role, UserStatus? status, Gender? gender, int pageNumber, int pageSize);
}
