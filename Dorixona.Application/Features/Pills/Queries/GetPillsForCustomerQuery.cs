namespace Dorixona.Application.Features.Pills.Queries;

public sealed record GetPillsForCustomerQuery(
    string? Name = null,
    string? PillType = null,
    Guid? PharmacyId = null,
    bool OnlyAvailable = true,
    int PageNumber = 1,
    int PageSize = 20
);
