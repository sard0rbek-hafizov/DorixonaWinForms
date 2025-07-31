using Dorixona.Domain.Models.AdminModel.AdminEntities;
using System.Linq.Expressions;

namespace Dorixona.Domain.Models.AdminModel.AdminSpecifications;

public class AdminIncludeAllSpec : ISpecification<Admin>
{
    public Expression<Func<Admin, bool>>? Criteria => null;
    public List<Expression<Func<Admin, object>>> Includes { get; } = new()
{
    a => a.User!,
    a => a.Pharmacists!,
    a => a.Pharmacies!,
    a => a.Pills!,
    a => a.Patients!,
    a => a.Orders!
};
    public Func<IQueryable<Admin>, IOrderedQueryable<Admin>>? OrderBy => null;
    public int? Skip => null;
    public int? Take => null;
}
