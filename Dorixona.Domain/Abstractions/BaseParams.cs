using System.ComponentModel.DataAnnotations;

namespace Dorixona.Domain.Abstractions;
public class BaseParams : Entity
{
    [Required]
    public DateTime CreateDate { get; set; }
    [Required]
    public DateTime UpdateDate { get; set; }
    [Required]
    public DateTime? DeleteDate { get; set; }
    [Required]
    public bool IsDelete { get; set; }
}
