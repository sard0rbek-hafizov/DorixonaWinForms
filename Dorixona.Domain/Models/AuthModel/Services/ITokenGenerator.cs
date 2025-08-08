using Dorixona.Domain.Models.AuthModel.Entities;
using Dorixona.Domain.Models.UserModel.UserEntities;

namespace Dorixona.Domain.Models.AuthModel.Services;

public interface ITokenGenerator
{
    string GenerateAccessToken(User user);             // JWT access token
    RefreshToken GenerateRefreshToken(User user);      // DB uchun refresh token
}
