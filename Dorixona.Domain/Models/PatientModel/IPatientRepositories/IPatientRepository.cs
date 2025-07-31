using Dorixona.Domain.Models.PatientModel.PatientEntities;

namespace Dorixona.Domain.Models.PatientModel.IPatientRepositories;

public interface IPatientRepository
{
    Task<Patient?> GetByIdAsync(Guid patientId);
    Task<IEnumerable<Patient>> GetAllAsync();
    Task AddAsync(Patient patient);
    Task UpdateAsync(Patient patient);
    Task DeleteAsync(Guid patientId);
}
