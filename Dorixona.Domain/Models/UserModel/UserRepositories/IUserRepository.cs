using Dorixona.Domain.Enums;
using Dorixona.Domain.Models.UserModel.UserEntities;

namespace Dorixona.Domain.Models.UserModel.UserRepositories;
public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> GetByEmailAsync(string email);
    Task<List<User>> GetAllAsync();
    Task<List<User>> GetFilteredAsync(string? fullName, string? email, Role? role, UserStatus? status, Gender? gender, int pageNumber, int pageSize);

    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(User user);
}