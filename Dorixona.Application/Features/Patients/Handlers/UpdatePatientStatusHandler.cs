using Dorixona.Domain.Models.PatientModel.IPatientRepositories;
using Dorixona.Domain.Models.PatientModel.PatientDTO;

namespace Dorixona.Application.Features.Patients.Handlers;

public class UpdatePatientStatusHandler
{
    private readonly IPatientRepository _patientRepository;

    public UpdatePatientStatusHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<bool> HandleAsync(PatientStatusUpdateDto dto)
    {
        var patient = await _patientRepository.GetByIdAsync(dto.Id);
        if (patient is null) return false;

        patient.Status = dto.Status;
        patient.IsDeleted = dto.IsDeleted;

        await _patientRepository.UpdateAsync(patient);
        return true;
    }
}
