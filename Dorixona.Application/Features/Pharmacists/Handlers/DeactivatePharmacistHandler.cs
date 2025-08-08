using Dorixona.Application.Features.Pharmacists.Commands;
using Dorixona.Domain.Models.PharmacistModel.IPharmacistRepositories;
using MediatR;

namespace Dorixona.Application.Features.Pharmacists.Handlers;

public class DeactivatePharmacistHandler : IRequestHandler<DeactivatePharmacistCommand, bool>
{
    private readonly IPharmacistRepository _repository;

    public DeactivatePharmacistHandler(IPharmacistRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeactivatePharmacistCommand request, CancellationToken cancellationToken)
    {
        var pharmacist = await _repository.GetByIdAsync(request.PharmacistId);
        if (pharmacist is null) return false;

        pharmacist.IsActive = false;
        await _repository.UpdateAsync(pharmacist);
        return true;
    }
}