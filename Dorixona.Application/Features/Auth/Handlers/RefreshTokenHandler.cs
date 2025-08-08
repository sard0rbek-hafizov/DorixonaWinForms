using Dorixona.Application.Features.Auth.Commands;
using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.AuthModel.AuthDTO;
using Dorixona.Domain.Models.AuthModel.Repositories;
using Dorixona.Domain.Models.AuthModel.Services;
using Dorixona.Domain.Models.AuthModel.Specs;
using Dorixona.Domain.Models.UserModel.UserRepositories;

namespace Dorixona.Application.Features.Auth.Handlers;

public class RefreshTokenHandler
{
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IUserRepository _userRepository;
    private readonly ITokenGenerator _tokenGenerator;

    public RefreshTokenHandler(IRefreshTokenRepository refreshTokenRepository, IUserRepository userRepository, ITokenGenerator tokenGenerator)
    {
        _refreshTokenRepository = refreshTokenRepository;
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<Result<TokenDto>> HandleAsync(RefreshTokenCommand command)
    {
        var token = await _refreshTokenRepository.GetByTokenAsync(command.RefreshToken);
        if (token is null || !AuthTokenSpecs.IsValid(token) || !AuthTokenSpecs.BelongsToDevice(token, command.DeviceId))
            return Result<TokenDto>.Failure(Error.Conflict("Invalid refresh token."));

        var user = await _userRepository.GetByIdAsync(token.UserId);
        if (user is null)
            return Result<TokenDto>.Failure(Error.Conflict("User not found."));

        // Generate new tokens
        var newAccessToken = _tokenGenerator.GenerateAccessToken(user);
        var newRefreshToken = _tokenGenerator.GenerateRefreshToken(user);

        // Revoke old token
        token.Revoke();
        await _refreshTokenRepository.InvalidateTokenAsync(token.Id);

        // Save new token
        await _refreshTokenRepository.AddAsync(newRefreshToken);
        await _refreshTokenRepository.SaveChangesAsync();

        return Result<TokenDto>.Success(new TokenDto
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken.Token,
            ExpiresAt = newRefreshToken.ExpiresAt
        });
    }
}
