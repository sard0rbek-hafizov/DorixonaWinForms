using Dorixona.Domain.Models.PatientModel.IPatientRepositories;
using Dorixona.Domain.Models.PillsModel.PillEntities;
using MediatR;

namespace Dorixona.Application.Features.Patients.Queries;

public class SearchPillsQuery : IRequest<IEnumerable<Pill>>
{
    public string? SearchTerm { get; set; }
    public Guid? PharmacyId { get; set; }

    public class Handler : IRequestHandler<SearchPillsQuery, IEnumerable<Pill>>
    {
        private readonly IPatientSearchService _searchService;

        public Handler(IPatientSearchService searchService)
        {
            _searchService = searchService;
        }

        public async Task<IEnumerable<Pill>> Handle(SearchPillsQuery request, CancellationToken cancellationToken)
        {
            return await _searchService.SearchPillsAsync(request.SearchTerm, request.PharmacyId);
        }
    }
}

