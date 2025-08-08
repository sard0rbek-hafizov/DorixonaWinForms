using Dorixona.Application.Features.Auth.Commands;
using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.AuthModel.AuthDTO;
using Dorixona.Domain.Models.AuthModel.Repositories;
using Dorixona.Domain.Models.AuthModel.Services;
using Dorixona.Domain.Models.UserModel.UserEntities;
using Dorixona.Domain.Models.UserModel.UserRepositories;

namespace Dorixona.Application.Features.Auth.Handlers;

public class RegisterHandler
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly IUnitOfWork _iUnitOfWork;

    public RegisterHandler(IUserRepository userRepository, ITokenGenerator tokenGenerator, IRefreshTokenRepository refreshTokenRepository, IUnitOfWork iUnitOfWork)
    {
        _userRepository = userRepository;
        _tokenGenerator = tokenGenerator;
        _refreshTokenRepository = refreshTokenRepository;
        _iUnitOfWork = iUnitOfWork;
    }

    public async Task<Result<AuthResultDto>> HandleAsync(RegisterCommand command)
    {
        var dto = command.RegisterDto;

        var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
        if (existingUser is not null)
            return Result<AuthResultDto>.Failure(Error.Conflict("User with this email already exists."));

        var user = new User(dto.FirstName, dto.LastName, dto.MiddleName, dto.Email, dto.Password, dto.PhoneNumber);

        await _userRepository.AddAsync(user);
        await _iUnitOfWork.SaveChangesAsync();

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