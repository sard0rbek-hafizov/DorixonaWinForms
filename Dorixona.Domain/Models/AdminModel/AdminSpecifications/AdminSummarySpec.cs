using Dorixona.Domain.Models.AdminModel.AdminEntities;
using System.Linq.Expressions;

namespace Dorixona.Domain.Models.AdminModel.AdminSpecifications;

public class AdminSummarySpec : ISpecification<Admin>
{
    public Expression<Func<Admin, bool>>? Criteria => null;
    public List<Expression<Func<Admin, object>>> Includes { get; } = new()
{
    a => a.User!
};

    public Func<IQueryable<Admin>, IOrderedQueryable<Admin>>? OrderBy => q => q.OrderByDescending(a => a.CreateDate);
    public int? Skip => 0;
    public int? Take => 1;
}
