using Dorixona.Domain.Models.PatientModel.IPatientRepositories;
using Dorixona.Domain.Models.PatientModel.PatientDTO;
using Dorixona.Domain.Models.PatientModel.PatientEntities;

namespace Dorixona.Application.Features.Patients.Handlers;

public class CreatePatientHandler
{
    private readonly IPatientRepository _patientRepository;

    public CreatePatientHandler(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<Guid> HandleAsync(PatientCreateDto dto)
    {
        var patient = new Patient
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            MiddleName = dto.MiddleName,
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            PhoneNumber = dto.PhoneNumber,
            BirthDate = dto.BirthDate,
            Address = dto.Address,
            AllergyInfo = dto.AllergyInfo,
            MedicalHistory = dto.MedicalHistory,
            EmergencyContact = dto.EmergencyContact,
            HasChronicDiseases = dto.HasChronicDiseases,
            BloodType = dto.BloodType,
            Gender = dto.Gender.ToString(),
            RegisteredAt = DateTime.UtcNow
        };

        await _patientRepository.AddAsync(patient);
        return patient.Id;
    }
}
