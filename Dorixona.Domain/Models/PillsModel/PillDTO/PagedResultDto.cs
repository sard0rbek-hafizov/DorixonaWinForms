namespace Dorixona.Domain.Models.PillsModel.PillDTO;
public class PagedResultDto<T>
{
    public int TotalCount { get; set; }
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
    public IReadOnlyList<T> Items { get; set; } = new List<T>();
}
