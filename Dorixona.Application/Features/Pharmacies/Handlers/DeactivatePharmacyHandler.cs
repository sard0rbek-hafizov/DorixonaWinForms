using Dorixona.Application.Features.Pharmacies.Commands;
using Dorixona.Domain.Models.PharmacyModel.PharmacyRepositories;
using MediatR;

namespace Dorixona.Application.Features.Pharmacies.Handlers;

public class DeactivatePharmacyHandler : IRequestHandler<DeactivatePharmacyCommand, bool>
{
    private readonly IPharmacyService _service;

    public DeactivatePharmacyHandler(IPharmacyService service)
    {
        _service = service;
    }

    public async Task<bool> Handle(DeactivatePharmacyCommand request, CancellationToken cancellationToken)
    {
        var result = await _service.DeleteAsync(request.PharmacyId);
        return result.IsSuccess;
    }
}
