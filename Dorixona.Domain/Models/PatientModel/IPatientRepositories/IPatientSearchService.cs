using Dorixona.Domain.Models.PillsModel.PillEntities;

namespace Dorixona.Domain.Models.PatientModel.IPatientRepositories;

public interface IPatientSearchService
{
    Task<IEnumerable<Pill>> SearchPillsAsync(string? searchTerm, Guid? pharmacyId = null);
}
