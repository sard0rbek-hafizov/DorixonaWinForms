using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.UserModel.UserEntities;

namespace Dorixona.Domain.Models.UserModel.UserRepositories;

public interface IUserValidator
{
    Task<Result<bool>> ValidateCreateAsync(User user);
    Task<Result<bool>> ValidateUpdateAsync(User user);
}
