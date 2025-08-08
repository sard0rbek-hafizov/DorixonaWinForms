using Dorixona.Domain.Models.UserModel.UserRepositories;
using Dorixona.Domain.Models.UsrModel.UserResponses;
using Dorixona.Application.Features.Users.Queries;
namespace Dorixona.Application.Features.Users.Handlers;

public class GetUserByIdHandler
{
    private readonly IUserQueryService _queryService;

    public GetUserByIdHandler(IUserQueryService queryService)
    {
        _queryService = queryService;
    }

    public async Task<UserResponse?> HandleAsync(GetUserByIdQuery query)
    {
        return await _queryService.GetByIdAsync(query.Id);
    }
}
