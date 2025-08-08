using Dorixona.Application.Features.Pharmacies.Commands;
using Dorixona.Domain.Models.PharmacyModel.PharmacyRepositories;
using MediatR;

namespace Dorixona.Application.Features.Pharmacies.Handlers;

public class CreatePharmacyHandler : IRequestHandler<CreatePharmacyCommand, bool>
{
    private readonly IPharmacyService _service;

    public CreatePharmacyHandler(IPharmacyService service)
    {
        _service = service;
    }

    public async Task<bool> Handle(CreatePharmacyCommand request, CancellationToken cancellationToken)
    {
        var result = await _service.CreateAsync(request.Dto);
        return result.IsSuccess;
    }
}
