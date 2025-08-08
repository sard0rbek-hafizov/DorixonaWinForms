using Dorixona.Domain.Models.PatientModel.IPatientRepositories;
using Dorixona.Domain.Models.PatientModel.PatientEntities;

namespace Dorixona.Application.Features.Patients.Handlers;

public class GetPatientByIdHandler
{
    private readonly IPatientQueryService _queryService;

    public GetPatientByIdHandler(IPatientQueryService queryService)
    {
        _queryService = queryService;
    }

    public async Task<Patient?> HandleAsync(Guid patientId)
    {
        return await _queryService.GetPatientProfileAsync(patientId);
    }
}
