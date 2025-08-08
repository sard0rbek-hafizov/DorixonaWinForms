using Dorixona.Domain.Models.PatientModel.IPatientRepositories;
using Dorixona.Domain.Models.PillsModel.PillEntities;

namespace Dorixona.Application.Features.Patients.Handlers;

public class SearchPillsHandler
{
    private readonly IPatientSearchService _searchService;

    public SearchPillsHandler(IPatientSearchService searchService)
    {
        _searchService = searchService;
    }

    public async Task<IEnumerable<Pill>> HandleAsync(string searchTerm)
    {
        return await _searchService.SearchPillsAsync(searchTerm);
    }
}
