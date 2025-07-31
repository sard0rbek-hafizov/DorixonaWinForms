using System;

namespace Dorixona.Domain.Models.UserModel.UserExceptions;

public class InvalidCredentialsException : Exception
{
    public InvalidCredentialsException()
        : base("Email yoki parol noto‘g‘ri.") { }

    public InvalidCredentialsException(string message)
        : base(message) { }
}
