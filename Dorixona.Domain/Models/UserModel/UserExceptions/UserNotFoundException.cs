using System;

namespace Dorixona.Domain.Models.UserModel.UserExceptions;

public class UserNotFoundException : Exception
{
    public UserNotFoundException()
        : base("Foydalanuvchi topilmadi.") { }

    public UserNotFoundException(string message)
        : base(message) { }
}
