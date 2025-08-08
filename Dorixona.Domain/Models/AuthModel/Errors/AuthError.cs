using Dorixona.Domain.Abstractions;

namespace Dorixona.Domain.Models.AuthModel.Errors;

public static class AuthError
{
    public static Error EmailAlreadyExists =>
        new Error("Email already registered", "Auth.EmailAlreadyExists");

    public static Error InvalidCredentials =>
        new Error("Invalid email or password", "Auth.InvalidCredentials");

    public static Error EmailNotConfirmed =>
        new Error("Email is not confirmed", "Auth.EmailNotConfirmed");

    public static Error UserIsLockedOut =>
        new Error("User is locked out", "Auth.UserLockedOut");

    public static Error RefreshTokenExpired =>
        new Error("Refresh token has expired", "Auth.RefreshTokenExpired");

    public static Error AccessDenied =>
        new Error("Access denied", "Auth.AccessDenied");

    public static Error InvalidRefreshToken =>
        new Error("Invalid refresh token", "Auth.InvalidRefreshToken");
}
