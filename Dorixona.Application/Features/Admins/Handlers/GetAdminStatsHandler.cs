using Dorixona.Domain.Models.AdminModel.AdminDTO;
using Dorixona.Domain.Models.AdminModel.IAdminRepositories;

namespace Dorixona.Application.Features.Admins.Handlers;

public class GetAdminStatsHandler
{
    private readonly IAdminQueryService _queryService;

    public GetAdminStatsHandler(IAdminQueryService queryService)
    {
        _queryService = queryService;
    }

    public async Task<AdminStatsDto> HandleAsync()
    {
        return await _queryService.GetStatisticsAsync();
    }
}
