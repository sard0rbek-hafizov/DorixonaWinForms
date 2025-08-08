using Dorixona.Domain.Models.AdminModel.AdminDTO;
using Dorixona.Domain.Models.AdminModel.IAdminRepositories;

namespace Dorixona.Application.Features.Admins.Handlers;

public class ListAdminsHandler
{
    private readonly IAdminQueryService _queryService;

    public ListAdminsHandler(IAdminQueryService queryService)
    {
        _queryService = queryService;
    }

    public async Task<List<AdminViewDto>> HandleAsync()
    {
        return await _queryService.GetAllAsync();
    }
}
