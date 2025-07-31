using Dorixona.Domain.Abstractions;
namespace Dorixona.Domain.Models.PharmacyModel.PharmacyErrors;

public static class PharmacyError
{
    public static readonly Error PharmacyNotFound = new("Dorixona topilmadi.", "Pharmacy.NotFound");
    public static readonly Error NameAlreadyExists = new("Bu nomdagi dorixona allaqachon mavjud.", "Pharmacy.NameExists");
    public static readonly Error InvalidPhoneNumber = new("Telefon raqami noto‘g‘ri formatda.", "Pharmacy.InvalidPhone");
    public static readonly Error LocationRequired = new("Dorixonaning manzili ko‘rsatilmagan.", "Pharmacy.LocationRequired");
    public static readonly Error AccessDenied = new("Sizga bu dorixonani boshqarishga ruxsat yo‘q.", "Pharmacy.AccessDenied");
    public static readonly Error Unauthorized = new("Avtorizatsiyadan o‘ting.", "Pharmacy.Unauthorized");
    public static readonly Error AlreadyDeleted = new("Bu dorixona allaqachon o‘chirib tashlangan.", "Pharmacy.AlreadyDeleted");
}
