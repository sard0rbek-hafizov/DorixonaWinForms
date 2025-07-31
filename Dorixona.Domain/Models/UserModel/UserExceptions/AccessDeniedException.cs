using System;

namespace Dorixona.Domain.Models.UserModel.UserExceptions;

public class AccessDeniedException : Exception
{
    public AccessDeniedException()
        : base("Sizga bu amalni bajarishga ruxsat yo‘q.") { }

    public AccessDeniedException(string message)
        : base(message) { }
}
