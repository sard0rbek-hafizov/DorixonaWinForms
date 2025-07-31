using Dorixona.Domain.Models.UserModel.UserEntities;
using Dorixona.Domain.Models.UsrModel.UserDTO;

namespace Dorixona.Domain.Models.UserModel.UserSpecifications;
public interface IUserSpecification
{
    IQueryable<User> ApplyFilter(IQueryable<User> query, UserFilterDto filterDto);
}
