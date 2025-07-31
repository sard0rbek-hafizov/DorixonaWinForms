using Dorixona.Domain.Models.AdminModel.AdminEntities;
using System.Linq.Expressions;

namespace Dorixona.Domain.Models.AdminModel.AdminSpecifications;

public class AdminActiveOnlySpec : ISpecification<Admin>
{
    public Expression<Func<Admin, bool>>? Criteria { get; }
    public List<Expression<Func<Admin, object>>> Includes { get; } = new()
{
    a => a.User!
};

    public Func<IQueryable<Admin>, IOrderedQueryable<Admin>>? OrderBy => null;
    public int? Skip => null;
    public int? Take => null;

    public AdminActiveOnlySpec()
    {
        Criteria = a => a.User!.Status == UserStatus.Active;
    }
}
