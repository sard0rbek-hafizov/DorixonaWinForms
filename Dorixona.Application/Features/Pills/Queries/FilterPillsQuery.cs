namespace Dorixona.Application.Features.Pills.Queries;

public sealed record FilterPillsQuery(
    string? Name,
    string? Manufacturer,
    string? PillType,
    Guid? PharmacyId,
    int PageNumber = 1,
    int PageSize = 10
);