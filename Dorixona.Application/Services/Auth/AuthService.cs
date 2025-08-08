using Dorixona.Application.Interfaces;
using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Enums;
using Dorixona.Domain.Models.AuthModel.AuthDTO;
using Dorixona.Domain.Models.AuthModel.Entities;
using Dorixona.Domain.Models.AuthModel.Repositories;
using Dorixona.Domain.Models.UserModel.UserEntities;
using Dorixona.Domain.Models.UserModel.UserRepositories;

namespace Dorixona.Application.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly ILoginHistoryRepository _loginHistoryRepository;
    private readonly ITokenService _tokenService;
    private readonly IUnitOfWork _unitOfWork;

    public AuthService(
        IUserRepository userRepository,
        IRefreshTokenRepository refreshTokenRepo,
        ILoginHistoryRepository loginHistoryRepo,
        ITokenService tokenService,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _refreshTokenRepository = refreshTokenRepo;
        _loginHistoryRepository = loginHistoryRepo;
        _tokenService = tokenService;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<AuthResultDto>> LoginAsync(LoginDto dto)
    {
        var user = await _userRepository.GetByEmailAsync(dto.Email);
        if (user is null || !_tokenService.VerifyPassword(dto.Password, user.PasswordHash))
        {
            var failedHistory = new LoginHistory(Guid.NewGuid(), false, "Unknown", "Unknown", "Noto'g'ri email yoki parol");
            await _loginHistoryRepository.AddAsync(failedHistory);
            return Result<AuthResultDto>.Failure(Error.Conflict("Email yoki parol noto'g'ri."));
        }

        if (user.Status != UserStatus.Active)
        {
            return Result<AuthResultDto>.Failure(Error.Conflict("Foydalanuvchi bloklangan."));
        }

        var (accessToken, refreshToken, expires) = _tokenService.GenerateTokens(user.Id, user.Email);

        var refreshTokenEntity = new RefreshToken(user.Id, refreshToken, expires.RefreshExpiresAt, "Unknown", "Unknown", Guid.NewGuid().ToString());
        await _refreshTokenRepository.AddAsync(refreshTokenEntity);

        var history = new LoginHistory(user.Id, true, "Unknown", "Unknown");
        await _loginHistoryRepository.AddAsync(history);

        user.LastLoginAt = DateTime.UtcNow;
        await _userRepository.UpdateAsync(user);

        await _unitOfWork.SaveChangesAsync();

        var result = new AuthResultDto
        {
            UserId = user.Id,
            FullName = user.FullName,
            Role = user.Role.ToString(),
            Token = new TokenDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresAt = expires.AccessExpiresAt
            }
        };

        return Result<AuthResultDto>.Success(result);
    }

    public async Task<Result> LogoutAsync(Guid userId)
    {
        await _refreshTokenRepository.InvalidateAllActiveTokensAsync(userId);
        await _unitOfWork.SaveChangesAsync();
        return Result.Success();
    }

    public async Task<Result<TokenDto>> RefreshTokenAsync(string refreshToken)
    {
        var existing = await _refreshTokenRepository.GetByTokenAsync(refreshToken);
        if (existing is null || existing.IsExpired() || existing.Status != TokenStatus.Active)
        {
            return Result<TokenDto>.Failure(Error.Conflict("Refresh token yaroqsiz."));
        }

        var user = await _userRepository.GetByIdAsync(existing.UserId);
        if (user is null || user.Status != UserStatus.Active)
        {
            return Result<TokenDto>.Failure(Error.Conflict("Foydalanuvchi topilmadi yoki bloklangan."));
        }

        existing.MarkAsUsed();

        var (newAccessToken, newRefreshToken, expires) = _tokenService.GenerateTokens(user.Id, user.Email);

        var newRefreshTokenEntity = new RefreshToken(user.Id, newRefreshToken, expires.RefreshExpiresAt, existing.IpAddress, existing.Device, Guid.NewGuid().ToString());
        await _refreshTokenRepository.AddAsync(newRefreshTokenEntity);

        await _unitOfWork.SaveChangesAsync();

        return Result<TokenDto>.Success(new TokenDto
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken,
            ExpiresAt = expires.AccessExpiresAt
        });
    }

    public async Task<Result<AuthResultDto>> RegisterAsync(RegisterDto dto)
    {
        var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
        if (existingUser is not null)
        {
            return Result<AuthResultDto>.Failure(Error.Conflict("Bunday email mavjud."));
        }

        var hashedPassword = _tokenService.HashPassword(dto.Password);

        var user = new User
        {
            Id = Guid.NewGuid(),
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            MiddleName = dto.MiddleName,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            PasswordHash = hashedPassword,
            Role = Role.Patient,
            Status = UserStatus.Active,
            RegisteredAt = DateTime.UtcNow
        };

        await _userRepository.AddAsync(user);

        var (accessToken, refreshToken, expires) = _tokenService.GenerateTokens(user.Id, user.Email);

        var refreshTokenEntity = new RefreshToken(user.Id, refreshToken, expires.RefreshExpiresAt, "Unknown", "Unknown", Guid.NewGuid().ToString());
        await _refreshTokenRepository.AddAsync(refreshTokenEntity);

        await _unitOfWork.SaveChangesAsync();

        var result = new AuthResultDto
        {
            UserId = user.Id,
            FullName = user.FullName,
            Role = user.Role.ToString(),
            Token = new TokenDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                ExpiresAt = expires.AccessExpiresAt
            }
        };

        return Result<AuthResultDto>.Success(result);
    }
}
