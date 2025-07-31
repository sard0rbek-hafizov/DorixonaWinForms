using Dorixona.Domain.Models.AdminModel.AdminDTO;
using Dorixona.Domain.Models.AdminModel.AdminEntities;
using System.Linq.Expressions;

namespace Dorixona.Domain.Models.AdminModel.AdminSpecifications;

public class AdminPaginationSpec : ISpecification<Admin>
{
    public Expression<Func<Admin, bool>>? Criteria { get; }
    public List<Expression<Func<Admin, object>>> Includes { get; } = new();
    public Func<IQueryable<Admin>, IOrderedQueryable<Admin>>? OrderBy { get; }
    public int? Skip { get; }
    public int? Take { get; }

    public AdminPaginationSpec(AdminPaginationDto dto)
    {
        Criteria = string.IsNullOrWhiteSpace(dto.Search)
            ? null
            : a => a.User!.FirstName.Contains(dto.Search) ||
                   a.User!.LastName.Contains(dto.Search) ||
                   a.User!.Email.Contains(dto.Search);

        OrderBy = dto.SortOrder?.ToLower() == "desc"
            ? q => q.OrderByDescending(GetSortExpression(dto.SortBy))
            : q => q.OrderBy(GetSortExpression(dto.SortBy));

        Skip = (dto.PageNumber - 1) * dto.PageSize;
        Take = dto.PageSize;

        Includes.Add(a => a.User!);
    }

    private Expression<Func<Admin, object>> GetSortExpression(string? sortBy)
    {
        return sortBy?.ToLower() switch
        {
            "firstname" => a => a.User!.FirstName,
            "email" => a => a.User!.Email,
            "createdat" => a => a.CreateDate,
            _ => a => a.CreateDate
        };
    }
}
