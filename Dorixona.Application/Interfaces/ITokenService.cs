namespace Dorixona.Application.Interfaces;

public interface ITokenService
{
    (string AccessToken, string RefreshToken, (DateTime AccessExpiresAt, DateTime RefreshExpiresAt))
        GenerateTokens(Guid userId, string email);

    string HashPassword(string password);
    bool VerifyPassword(string password, string hash);
}
