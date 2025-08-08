using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.PillsModel.IPillRepositories;
using MediatR;

namespace Dorixona.Application.Features.Pills.Commands;

public class DeletePillCommand : IRequest<Result>
{
    public Guid PillId { get; set; }
}

public class DeletePillCommandHandler : IRequestHandler<DeletePillCommand, Result>
{
    private readonly IPillRepository _pillRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePillCommandHandler(IPillRepository pillRepository, IUnitOfWork unitOfWork)
    {
        _pillRepository = pillRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeletePillCommand request, CancellationToken cancellationToken)
    {
        var existingResult = await _pillRepository.GetByIdAsync(request.PillId, cancellationToken);
        if (!existingResult.IsSuccess)
            return Result.Failure(existingResult.Error!);

        var pill = existingResult.Value!;
        var deleteResult = await _pillRepository.DeleteAsync(pill, cancellationToken);
        if (!deleteResult.IsSuccess)
            return Result.Failure(deleteResult.Error!);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return Result.Success();
    }
}
