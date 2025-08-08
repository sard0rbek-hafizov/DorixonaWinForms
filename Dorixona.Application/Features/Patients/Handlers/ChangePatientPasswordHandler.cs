using Dorixona.Domain.Models.PatientModel.IPatientRepositories;
using Dorixona.Domain.Models.PatientModel.PatientDTO;

namespace Dorixona.Application.Features.Patients.Handlers;

public class ChangePatientPasswordHandler
{
    private readonly IPatientRepository _patientRepository;

    public ChangePatientPasswordHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<bool> HandleAsync(Guid patientId, PatientChangePasswordDto dto)
    {
        var patient = await _patientRepository.GetByIdAsync(patientId);
        if (patient is null) return false;

        if (!BCrypt.Net.BCrypt.Verify(dto.CurrentPassword, patient.PasswordHash))
            return false;

        patient.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);

        await _patientRepository.UpdateAsync(patient);
        return true;
    }
}
