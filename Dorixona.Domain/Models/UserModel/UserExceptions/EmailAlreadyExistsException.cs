using System;

namespace Dorixona.Domain.Models.UserModel.UserExceptions;

public class EmailAlreadyExistsException : Exception
{
    public EmailAlreadyExistsException()
        : base("Bu email allaqachon ro‘yxatdan o‘tgan.") { }

    public EmailAlreadyExistsException(string message)
        : base(message) { }
}
