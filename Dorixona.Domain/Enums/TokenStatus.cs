namespace Dorixona.Domain.Enums;

public enum TokenStatus
{
    Active = 0,      // Hozircha ishlatilmagan va yaroqli token
    Consumed = 1,    // Bir marta ishlatilgan token (endi ishlatib bo‘lmaydi)
    Expired = 2,     // Muddatidan o‘tgan token
    Revoked = 3      // Admin yoki tizim tomonidan bekor qilingan token
}
