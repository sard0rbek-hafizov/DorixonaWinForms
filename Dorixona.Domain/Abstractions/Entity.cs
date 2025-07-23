using System.ComponentModel.DataAnnotations;
namespace Dorixona.Domain.Abstractions;
public abstract class Entity
{
    [Key]
    public Guid Id { get; set; }
}
