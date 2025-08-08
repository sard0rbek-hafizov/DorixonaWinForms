using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.AdminModel.AdminDTO;
using Dorixona.Domain.Models.AdminModel.IAdminRepositories;

namespace Dorixona.Application.Features.Admins.Handlers;

public class LogAdminActivityHandler
{
    private readonly IAdminActivityLogRepository _logRepository;

    public LogAdminActivityHandler(IAdminActivityLogRepository logRepository)
    {
        _logRepository = logRepository;
    }

    public async Task<Result> HandleAsync(AdminActivityLogDto dto)
    {
        if (dto.PerformedAt > DateTime.UtcNow)
            return Result.Failure(Error.Validation("PerformedAt cannot be in future"));

        await _logRepository.LogActivityAsync(dto);
        return Result.Success();
    }
}
