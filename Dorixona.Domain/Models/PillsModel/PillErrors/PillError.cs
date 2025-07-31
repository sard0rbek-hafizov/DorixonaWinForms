using Dorixona.Domain.Abstractions;

namespace Dorixona.Domain.Models.PillsModel.PillErrors;

public static class PillError
{
    public static readonly Error PillNotFound = new("Pill.NotFound", "Bunday dori mavjud emas.");
    public static readonly Error DuplicateName = new("Pill.DuplicateName", "Bu nomdagi dori allaqachon mavjud.");
    public static readonly Error InvalidType = new("Pill.InvalidType", "Dori turi noto‘g‘ri ko‘rsatilgan.");
    public static readonly Error Expired = new("Pill.Expired", "Dorining yaroqlilik muddati tugagan.");
    public static readonly Error OutOfStock = new("Pill.OutOfStock", "Dori omborda qolmagan.");
    public static readonly Error UnauthorizedAccess = new("Pill.UnauthorizedAccess", "Bu amalni bajarishga ruxsat yo‘q.");
}
