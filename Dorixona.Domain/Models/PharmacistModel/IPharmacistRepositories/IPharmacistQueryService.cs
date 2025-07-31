using Dorixona.Domain.Models.PharmacistModel.PharmacistDTO;

namespace Dorixona.Domain.Models.PharmacistModel.IPharmacistRepositories;

public interface IPharmacistQueryService
{
    Task<PharmacistDetailsDto?> GetDetailsByIdAsync(Guid id);
    Task<IReadOnlyList<PharmacistListDto>> GetAllAsync();
    Task<IReadOnlyList<PharmacistListDto>> GetByPharmacyIdAsync(Guid pharmacyId);
    Task<IReadOnlyList<PharmacistListDto>> SearchAsync(string? searchText);
    Task<IReadOnlyList<PharmacistListDto>> GetPaginatedAsync(int page, int pageSize);
}