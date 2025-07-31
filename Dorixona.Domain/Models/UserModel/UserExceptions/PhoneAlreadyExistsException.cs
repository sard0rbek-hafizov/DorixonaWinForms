using System;

namespace Dorixona.Domain.Models.UserModel.UserExceptions;

public class PhoneAlreadyExistsException : Exception
{
    public PhoneAlreadyExistsException()
        : base("Bu telefon raqami allaqachon mavjud.") { }

    public PhoneAlreadyExistsException(string message)
        : base(message) { }
}
