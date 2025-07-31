using Dorixona.Domain.Models.UserModel.UserEntities;
using Dorixona.Domain.Models.UsrModel.UserDTO;

namespace Dorixona.Domain.Models.UserModel.UserSpecifications;

public class UserSpecification : IUserSpecification
{
    public IQueryable<User> ApplyFilter(IQueryable<User> query, UserFilterDto filterDto)
    {
        if (!string.IsNullOrWhiteSpace(filterDto.FullName))
        {
            string name = filterDto.FullName.ToLower();
            query = query.Where(u =>
                (u.FirstName + " " + u.LastName + " " + u.MiddleName).ToLower().Contains(name));
        }

        if (!string.IsNullOrWhiteSpace(filterDto.Email))
            query = query.Where(u => u.Email.ToLower().Contains(filterDto.Email.ToLower()));

        if (filterDto.Role.HasValue)
            query = query.Where(u => u.Role == filterDto.Role);

        if (filterDto.Gender.HasValue)
            query = query.Where(u => u.Gender == filterDto.Gender);

        if (filterDto.Status.HasValue)
            query = query.Where(u => u.Status == filterDto.Status);

        // Pagination
        int skip = (filterDto.PageNumber - 1) * filterDto.PageSize;
        query = query.Skip(skip).Take(filterDto.PageSize);

        return query;
    }
}
