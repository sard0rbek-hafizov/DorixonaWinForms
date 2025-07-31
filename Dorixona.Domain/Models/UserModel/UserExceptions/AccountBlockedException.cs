using System;

namespace Dorixona.Domain.Models.UserModel.UserExceptions;

public class AccountBlockedException : Exception
{
    public AccountBlockedException()
        : base("Sizning profilingiz bloklangan.") { }

    public AccountBlockedException(string message)
        : base(message) { }
}
