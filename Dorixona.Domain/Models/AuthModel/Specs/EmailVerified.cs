using Dorixona.Domain.Models.UserModel.UserEntities;

namespace Dorixona.Domain.Models.AuthModel.Specs;

public static class EmailVerified
{
    public static bool IsSatisfiedBy(User user)
    {
        return user.EmailVerifiedAt.HasValue;
    }
}
