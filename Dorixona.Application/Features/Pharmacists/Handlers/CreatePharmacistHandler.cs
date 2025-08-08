using Dorixona.Application.Features.Pharmacists.Commands;
using Dorixona.Domain.Models.PharmacistModel.IPharmacistRepositories;
using MediatR;

namespace Dorixona.Application.Features.Pharmacists.Handlers;

public class CreatePharmacistHandler : IRequestHandler<CreatePharmacistCommand, bool>
{
    private readonly IPharmacistService _service;

    public CreatePharmacistHandler(IPharmacistService service)
    {
        _service = service;
    }

    public async Task<bool> Handle(CreatePharmacistCommand request, CancellationToken cancellationToken)
    {
        var result = await _service.CreateAsync(request.Dto);
        return result.IsSuccess;
    }
}