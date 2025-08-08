using Dorixona.Domain.Models.PatientModel.IPatientRepositories;
using Dorixona.Domain.Models.PillsModel.PillEntities;

namespace Dorixona.Application.Features.Patients.Handlers;

public class FilterAvailablePillsHandler
{
    private readonly IPatientSearchService _searchService;

    public FilterAvailablePillsHandler(IPatientSearchService searchService)
    {
        _searchService = searchService;
    }

    public async Task<IEnumerable<Pill>> HandleAsync(string? searchTerm, Guid? pharmacyId)
    {
        return await _searchService.SearchPillsAsync(searchTerm, pharmacyId);
    }
}
