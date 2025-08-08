namespace Dorixona.Application.Features.Pills.Queries;

public sealed record GetPillsForSellerQuery(
    Guid SellerId,
    string? SearchTerm = null,
    int PageNumber = 1,
    int PageSize = 20
);
