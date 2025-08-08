using Dorixona.Domain.Models.UsrModel.UserDTO;

namespace Dorixona.Application.Features.Users.Queries;


public class GetAllUsersQuery
{
    public UserFilterDto Filter { get; set; }

    public GetAllUsersQuery(UserFilterDto filter)
    {
        Filter = filter;
    }
}