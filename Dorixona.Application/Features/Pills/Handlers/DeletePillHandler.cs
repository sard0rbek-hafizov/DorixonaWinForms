using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.PillsModel.IPillRepositories;

namespace Dorixona.Application.Features.Pills.Handlers;

public class DeletePillHandler
{
    private readonly IPillRepository _pillRepository;

    public DeletePillHandler(IPillRepository pillRepository)
    {
        _pillRepository = pillRepository;
    }

    public async Task<Result<bool>> HandleAsync(Guid pillId, CancellationToken cancellationToken)
    {
        var result = await _pillRepository.GetByIdAsync(pillId, cancellationToken);
        if (result.IsFailure) return Result.Failure<bool>(result.Error);

        return await _pillRepository.DeleteAsync(result.Value, cancellationToken);
    }
}
