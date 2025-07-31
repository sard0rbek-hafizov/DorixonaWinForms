using System.Linq.Expressions;

namespace Dorixona.Domain.Abstractions;

public abstract class BaseSpecification<T>
{
    public Expression<Func<T, bool>>? Criteria { get; private set; }
    public List<Expression<Func<T, object>>> Includes { get; } = new();
    public List<string> IncludeStrings { get; } = new();

    public List<Expression<Func<T, object>>> OrderBy { get; } = new();
    public List<Expression<Func<T, object>>> OrderByDescending { get; } = new();

    //  Konstruktor: criteria qabul qiladi
    protected BaseSpecification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    // (optional) default konstruktor
    protected BaseSpecification() { }

    protected void AddInclude(Expression<Func<T, object>> includeExpression) =>
        Includes.Add(includeExpression);

    protected void AddInclude(string includeString) =>
        IncludeStrings.Add(includeString);

    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression) =>
        OrderBy.Add(orderByExpression);

    protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression) =>
        OrderByDescending.Add(orderByDescExpression);
}
