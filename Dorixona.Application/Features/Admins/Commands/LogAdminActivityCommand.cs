using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.AdminModel.AdminDTO;
using Dorixona.Domain.Models.AdminModel.IAdminRepositories;
using MediatR;

namespace Dorixona.Application.Features.Admins.Commands;

public class LogAdminActivityCommand : IRequest<Result>
{
    public AdminActivityLogDto LogDto { get; }

    public LogAdminActivityCommand(AdminActivityLogDto logDto)
    {
        LogDto = logDto;
    }
}

public class LogAdminActivityCommandHandler : IRequestHandler<LogAdminActivityCommand, Result>
{
    private readonly IAdminActivityLogRepository _logRepository;

    public LogAdminActivityCommandHandler(IAdminActivityLogRepository logRepository)
    {
        _logRepository = logRepository;
    }

    public async Task<Result> Handle(LogAdminActivityCommand request, CancellationToken cancellationToken)
    {
        var dto = request.LogDto;

        // Optional: Check if AdminId exists
        if (dto.PerformedAt > DateTime.UtcNow)
        {
            return Result.Failure(Error.Validation("Vaqt noto‘g‘ri belgilangan."));
        }

        await _logRepository.LogActivityAsync(dto);

        return Result.Success();
    }
}
