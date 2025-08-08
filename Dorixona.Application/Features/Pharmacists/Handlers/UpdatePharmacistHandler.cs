using Dorixona.Application.Features.Pharmacists.Commands;
using Dorixona.Domain.Models.PharmacistModel.IPharmacistRepositories;
using MediatR;

namespace Dorixona.Application.Features.Pharmacists.Handlers;

public class UpdatePharmacistHandler : IRequestHandler<UpdatePharmacistCommand, bool>
{
    private readonly IPharmacistService _service;

    public UpdatePharmacistHandler(IPharmacistService service)
    {
        _service = service;
    }

    public async Task<bool> Handle(UpdatePharmacistCommand request, CancellationToken cancellationToken)
    {
        var result = await _service.UpdateAsync(request.Dto);
        return result.IsSuccess;
    }
}
