using Dorixona.Domain.Models.PatientModel.PatientEntities;

namespace Dorixona.Domain.Models.PatientModel.IPatientRepositories;

public interface IPatientQueryService
{
    Task<Patient?> GetPatientProfileAsync(Guid patientId);
    Task<bool> PatientExistsAsync(Guid patientId);
}
