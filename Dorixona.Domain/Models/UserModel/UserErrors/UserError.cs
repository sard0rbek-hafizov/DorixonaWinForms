using Dorixona.Domain.Abstractions;

namespace Dorixona.Domain.Models.UsrModel.UserErrors;
public class UserError
{
    public static readonly Error UserNotFound = new("Foydalanuvchi topilmadi.", "User.NotFound");
    public static readonly Error InvalidEmailOrPassword = new("Email yoki parol noto‘g‘ri.", "User.InvalidCredentials");
    public static readonly Error EmailAlreadyExists = new("Bu email allaqachon ro‘yxatdan o‘tgan.", "User.EmailExists");
    public static readonly Error PhoneAlreadyExists = new("Bu telefon raqami allaqachon mavjud.", "User.PhoneExists");
    public static readonly Error AccessDenied = new("Sizga bu amalni bajarishga ruxsat yo‘q.", "User.AccessDenied");
    public static readonly Error IncorrectOldPassword = new("Eski parol noto‘g‘ri.", "User.IncorrectOldPassword");
    public static readonly Error WeakPassword = new("Parol juda oddiy. Kuchliroq parol tanlang.", "User.WeakPassword");
    public static readonly Error Unauthorized = new("Avtorizatsiyadan o‘ting.", "User.Unauthorized");
    public static readonly Error AccountIsBlocked = new("Sizning profilingiz bloklangan.", "User.Blocked");
}
