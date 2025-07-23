using Dorixona.Domain.Abstractions;

namespace Dorixona.Domain.Models.PillsModel;
public class PillError
{
    public static Error NotFound = new("Pill.NotFound", "Mavjud emas");
    public static Error PillNotFound = new("Pill.Failed", "Bunday dori mavjud emas");
}
