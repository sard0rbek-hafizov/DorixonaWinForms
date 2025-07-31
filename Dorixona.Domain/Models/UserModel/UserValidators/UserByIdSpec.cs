using Dorixona.Domain.Models.UserModel.UserEntities;
using Dorixona.Domain.Models.UsrModel;
using System.Linq.Expressions;

namespace Dorixona.Domain.Models.UsrModel.UserSpecifications;
public static class UserByIdSpec
{
    public static Expression<Func<User, bool>> ById(Guid id)
        => user => user.Id == id;
}
