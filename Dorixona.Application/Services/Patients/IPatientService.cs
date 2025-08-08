using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.PatientModel.PatientDTO;

namespace Dorixona.Application.Services.Patients;

public interface IPatientService
{
    Task<IEnumerable<PatientDto>> GetAllAsync();
    Task<PatientDto?> GetByIdAsync(Guid id);
    Task<Result<PatientDto>> CreateAsync(PatientCreateDto dto);
    Task<Result<PatientDto>> UpdateAsync(Guid id, PatientUpdateDto dto);
    Task<Result> DeleteAsync(Guid id);
}
