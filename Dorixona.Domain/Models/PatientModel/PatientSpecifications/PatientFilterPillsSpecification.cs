using Dorixona.Domain.Abstractions;
using Dorixona.Domain.Models.OrderModel.Entities;
using Dorixona.Domain.Models.PillsModel.PillDTO;

namespace Dorixona.Domain.Models.PatientModel.PatientSpecifications;

public class PatientFilterPillsSpecification : BaseSpecification<Order>
{
    public PatientFilterPillsSpecification(FilterPillDto filter)
        : base(x =>
            (string.IsNullOrEmpty(filter.Name) || x.Pill!.Name.Contains(filter.Name)) &&
            (string.IsNullOrEmpty(filter.Manufacturer) || x.Pill!.Manufacturer.Contains(filter.Manufacturer)) &&
            (!filter.MinPrice.HasValue || x.Pill!.Price >= filter.MinPrice.Value) &&
            (!filter.MaxPrice.HasValue || x.Pill!.Price <= filter.MaxPrice.Value) &&
            (!filter.MinExpiryDate.HasValue || x.Pill!.ExpiryDate >= filter.MinExpiryDate.Value) &&
            (!filter.MaxExpiryDate.HasValue || x.Pill!.ExpiryDate <= filter.MaxExpiryDate.Value) &&
            (!filter.MinStockQuantity.HasValue || x.Pill!.StockQuantity >= filter.MinStockQuantity.Value) &&
            (!filter.MaxStockQuantity.HasValue || x.Pill!.StockQuantity <= filter.MaxStockQuantity.Value) &&
            (!filter.PillType.HasValue || x.Pill!.PillType == filter.PillType) &&
            (!filter.PharmacyId.HasValue || x.Pill!.PharmacyId == filter.PharmacyId) &&
            (!filter.IsPrescriptionRequired.HasValue || x.Pill!.IsPrescriptionRequired == filter.IsPrescriptionRequired) &&
            (!filter.CategoryId.HasValue || x.Pill!.CategoryId == filter.CategoryId)
        )
    {
        AddInclude(x => x.Pill);
    }
}
