using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.AuthModel.AuthDTO;

namespace Dorixona.Application.Services.Auth;

public interface IAuthService
{
    Task<Result<AuthResultDto>> RegisterAsync(RegisterDto dto);
    Task<Result<AuthResultDto>> LoginAsync(LoginDto dto);
    Task<Result<TokenDto>> RefreshTokenAsync(string refreshToken);
    Task<Result> LogoutAsync(Guid userId);
}
