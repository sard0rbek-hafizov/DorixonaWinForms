using Dorixona.Domain.Models.AdminModel.AdminDTO;
using Dorixona.Domain.Models.AdminModel.AdminEntities;
using System.Linq.Expressions;

namespace Dorixona.Domain.Models.AdminModel.AdminSpecifications;

public class AdminFilterSpec : ISpecification<Admin>
{
    public Expression<Func<Admin, bool>>? Criteria { get; }
    public List<Expression<Func<Admin, object>>> Includes { get; } = new();
    public Func<IQueryable<Admin>, IOrderedQueryable<Admin>>? OrderBy => null;
    public int? Skip => null;
    public int? Take => null;

    public AdminFilterSpec(AdminFilterDto filter)
    {
        Criteria = admin =>
            (string.IsNullOrEmpty(filter.FirstName) || admin.User!.FirstName.Contains(filter.FirstName)) &&
            (string.IsNullOrEmpty(filter.LastName) || admin.User!.LastName.Contains(filter.LastName)) &&
            (string.IsNullOrEmpty(filter.Email) || admin.User!.Email.Contains(filter.Email)) &&
            (string.IsNullOrEmpty(filter.PhoneNumber) || admin.User!.PhoneNumber!.Contains(filter.PhoneNumber)) &&
            (!filter.Gender.HasValue || admin.User!.Gender == filter.Gender) &&
            (!filter.Role.HasValue || admin.User!.Role == filter.Role) &&
            (!filter.Status.HasValue || admin.User!.Status == filter.Status) &&
            (!filter.CreatedFrom.HasValue || admin.CreateDate >= filter.CreatedFrom) &&
            (!filter.CreatedTo.HasValue || admin.CreateDate <= filter.CreatedTo);

        Includes.Add(a => a.User!);
    }
}
