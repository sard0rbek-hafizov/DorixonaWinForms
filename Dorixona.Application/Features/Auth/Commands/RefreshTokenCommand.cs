namespace Dorixona.Application.Features.Auth.Commands;

public sealed record RefreshTokenCommand(string RefreshToken, string DeviceId);
