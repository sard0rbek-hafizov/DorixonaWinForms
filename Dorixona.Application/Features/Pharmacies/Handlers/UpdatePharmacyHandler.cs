using Dorixona.Application.Features.Pharmacies.Commands;
using Dorixona.Domain.Models.PharmacyModel.PharmacyRepositories;
using MediatR;

namespace Dorixona.Application.Features.Pharmacies.Handlers;

public class UpdatePharmacyHandler : IRequestHandler<UpdatePharmacyCommand, bool>
{
    private readonly IPharmacyService _service;

    public UpdatePharmacyHandler(IPharmacyService service)
    {
        _service = service;
    }

    public async Task<bool> Handle(UpdatePharmacyCommand request, CancellationToken cancellationToken)
    {
        var result = await _service.UpdateAsync(request.Dto);
        return result.IsSuccess;
    }
}
