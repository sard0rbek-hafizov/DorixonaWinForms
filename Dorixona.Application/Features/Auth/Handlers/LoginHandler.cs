using Dorixona.Application.Common.Helpers;
using Dorixona.Application.Features.Auth.Commands;
using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.AuthModel.AuthDTO;
using Dorixona.Domain.Models.AuthModel.Repositories;
using Dorixona.Domain.Models.AuthModel.Services;
using Dorixona.Domain.Models.UserModel.UserRepositories;

namespace Dorixona.Application.Features.Auth.Handlers;

public class LoginHandler
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public LoginHandler(IUserRepository userRepository, ITokenGenerator tokenGenerator, IRefreshTokenRepository refreshTokenRepository)
    {
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<Result<AuthResultDto>> HandleAsync(LoginCommand command)
    {
        var user = await _userRepository.GetByEmailAsync(command.Email);
        if (user is null || !BCrypt.Net.BCrypt.Verify(command.Password, user.PasswordHash))
        {
            return Result<AuthResultDto>.Failure(Error.Conflict("Email or password is incorrect."));
        }

        var accessToken = _tokenGenerator.GenerateAccessToken(user);
        var refreshToken = _tokenGenerator.GenerateRefreshToken(user);

        await _refreshTokenRepository.AddAsync(refreshToken);
        await _refreshTokenRepository.SaveChangesAsync();

        var authResult = new AuthResultDto
        {
            UserId = user.Id,
            FullName = user.FullName,
            Role = user.Role.ToString(),
            Token = new TokenDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token,
                ExpiresAt = refreshToken.ExpiresAt
            }
        };

        return Result<AuthResultDto>.Success(authResult);
    }
    
}

