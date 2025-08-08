using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Enums;
using Dorixona.Domain.Models.UserModel.UserEntities;

namespace Dorixona.Domain.Models.AuthModel.Rules;

public static class AuthBusinessRules
{
    public static Result<User> CheckIfUserExists(User? user)
    {
        return user is not null
            ? Result<User>.Success(user)
            : Result<User>.Failure(new Error("User not found", "User.NotFound"));
    }

    public static Result<User> CheckIfEmailConfirmed(User user)
    {
        return user.IsEmailConfirmed
            ? Result<User>.Success(user)
            : Result<User>.Failure(new Error("Email is not confirmed", "User.EmailNotConfirmed"));
    }

    public static Result<User> CheckIfPhoneConfirmed(User user)
    {
        return user.IsPhoneConfirmed
            ? Result<User>.Success(user)
            : Result<User>.Failure(new Error("Phone number is not confirmed", "User.PhoneNotConfirmed"));
    }

    public static Result<User> CheckIfUserIsActive(User user)
    {
        return user.Status == UserStatus.Active
            ? Result<User>.Success(user)
            : Result<User>.Failure(new Error("User is not active", "User.Inactive"));
    }

    public static Result<User> CheckIfUserIsNotLockedOut(User user)
    {
        if (user.LockoutEnd.HasValue && user.LockoutEnd > DateTime.UtcNow)
        {
            return Result<User>.Failure(new Error("User is locked out", "User.LockedOut"));
        }

        return Result<User>.Success(user);
    }

    public static Result<User> CheckIfUserNotDeleted(User user)
    {
        return user.IsDeleted
            ? Result<User>.Failure(new Error("User is deleted", "User.Deleted"))
            : Result<User>.Success(user);
    }

    public static Result<User> CheckIfRefreshTokenIsValid(User user, string providedToken)
    {
        if (string.IsNullOrEmpty(user.RefreshToken) || user.RefreshTokenExpiryTime is null)
        {
            return Result<User>.Failure(new Error("Refresh token not found", "Token.NotFound"));
        }

        if (user.RefreshTokenExpiryTime < DateTime.UtcNow)
        {
            return Result<User>.Failure(new Error("Refresh token has expired", "Token.Expired"));
        }

        if (user.RefreshToken != providedToken)
        {
            return Result<User>.Failure(new Error("Refresh token is invalid", "Token.Invalid"));
        }

        return Result<User>.Success(user);
    }
}
