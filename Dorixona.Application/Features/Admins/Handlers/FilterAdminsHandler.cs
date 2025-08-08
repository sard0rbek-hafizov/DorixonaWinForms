using Dorixona.Domain.Models.AdminModel.AdminDTO;
using Dorixona.Domain.Models.AdminModel.IAdminRepositories;

namespace Dorixona.Application.Features.Admins.Handlers;

public class FilterAdminsHandler
{
    private readonly IAdminQueryService _queryService;

    public FilterAdminsHandler(IAdminQueryService queryService)
    {
        _queryService = queryService;
    }

    public async Task<List<AdminViewDto>> HandleAsync(AdminFilterDto filter)
    {
        return await _queryService.FilterAsync(filter.FirstName,filter.Email);
    }
}
