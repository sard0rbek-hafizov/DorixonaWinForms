using Dorixona.Domain.Models.PatientModel.IPatientRepositories;
using Dorixona.Domain.Models.PatientModel.PatientDTO;

namespace Dorixona.Application.Features.Patients.Handlers;

public class UpdatePatientHandler
{
    private readonly IPatientRepository _patientRepository;

    public UpdatePatientHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<bool> HandleAsync(Guid patientId, PatientUpdateDto dto)
    {
        var patient = await _patientRepository.GetByIdAsync(patientId);
        if (patient is null) return false;

        patient.FirstName = dto.FirstName;
        patient.LastName = dto.LastName;
        patient.MiddleName = dto.MiddleName;
        patient.PhoneNumber = dto.PhoneNumber;
        patient.Address = dto.Address;
        patient.AllergyInfo = dto.AllergyInfo;
        patient.MedicalHistory = dto.MedicalHistory;
        patient.EmergencyContact = dto.EmergencyContact;
        patient.BloodType = dto.BloodType;
        patient.HasChronicDiseases = dto.HasChronicDiseases;
        patient.Gender = dto.Gender.ToString();

        await _patientRepository.UpdateAsync(patient);
        return true;
    }
}