namespace Dorixona.Application.Features.Pills.Queries;

public sealed record GetPillsForAdminQuery(
    string? SearchTerm = null,
    string? PillType = null,
    int PageNumber = 1,
    int PageSize = 20
);

