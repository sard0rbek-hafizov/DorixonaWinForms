using Dorixona.Domain.Models.UserModel.UserRepositories;
using Dorixona.Domain.Models.UsrModel.UserResponses;
using Dorixona.Application.Features.Users.Queries;
namespace Dorixona.Application.Features.Users.Handlers;

public class GetAllUsersHandler
{
    private readonly IUserQueryService _queryService;

    public GetAllUsersHandler(IUserQueryService queryService)
    {
        _queryService = queryService;
    }

    public async Task<List<UserResponse>> HandleAsync(GetAllUsersQuery query)
    {
        return await _queryService.GetFilteredAsync(
            query.Filter.FullName,
            query.Filter.Email,
            query.Filter.Role,
            query.Filter.Status,
            query.Filter.Gender,
            query.Filter.PageNumber,
            query.Filter.PageSize
        );
    }
}