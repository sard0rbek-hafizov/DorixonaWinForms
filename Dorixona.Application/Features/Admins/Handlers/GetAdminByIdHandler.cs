using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.AdminModel.AdminDTO;
using Dorixona.Domain.Models.AdminModel.IAdminRepositories;

namespace Dorixona.Application.Features.Admins.Handlers;

public class GetAdminByIdHandler
{
    private readonly IAdminQueryService _queryService;

    public GetAdminByIdHandler(IAdminQueryService queryService)
    {
        _queryService = queryService;
    }

    public async Task<Result<AdminViewDto>> HandleAsync(Guid id)
    {
        var dto = await _queryService.GetByIdWithUserAsync(id);
        if (dto is null)
            return Result<AdminViewDto>.Failure(Error.NotFound("Admin", id));

        return Result<AdminViewDto>.Success(dto);
    }
}
