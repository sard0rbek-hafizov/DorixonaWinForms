using Dorixona.Domain.Models.AdminModel.AdminEntities;
using System.Linq.Expressions;

namespace Dorixona.Domain.Models.AdminModel.AdminSpecifications;

public class AdminByIdSpec : ISpecification<Admin>
{
    public Expression<Func<Admin, bool>>? Criteria { get; }
    public List<Expression<Func<Admin, object>>> Includes { get; } = new();
    public Func<IQueryable<Admin>, IOrderedQueryable<Admin>>? OrderBy => null;
    public int? Skip => null;
    public int? Take => null;

    public AdminByIdSpec(Guid id)
    {
        Criteria = a => a.Id == id;
        Includes.Add(a => a.User!);
    }
}
