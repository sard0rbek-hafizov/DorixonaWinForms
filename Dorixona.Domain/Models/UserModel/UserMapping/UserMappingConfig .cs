using Dorixona.Domain.Models.UserModel.UserEntities;
using Dorixona.Domain.Models.UsrModel.UserDTO;
using Dorixona.Domain.Models.UsrModel.UserResponses;
using Mapster;

namespace Dorixona.Domain.Models.UserModel.UserMapping;
public class UserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // UserModel → UserResponse
        config.NewConfig<User, UserResponse>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.MiddleName, src => src.MiddleName)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.PhoneNumber, src => src.PhoneNumber)
            .Map(dest => dest.Role, src => src.Role)
            .Map(dest => dest.Gender, src => src.Gender);

        // CreateUserDto → UserModel
        config.NewConfig<UserCreateDto, User>()
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.MiddleName, src => src.MiddleName)
            .Map(dest => dest.Email, src => src.Email)
            .Map(dest => dest.PhoneNumber, src => src.PhoneNumber)
            .Map(dest => dest.Gender, src => src.Gender)
            .Map(dest => dest.Role, src => src.Role)
            .Map(dest => dest.PasswordHash, src => src.Password); // Hash qilinadi xizmatingizda

        // UpdateUserDto → UserModel (partial update uchun)
        config.NewConfig<UserUpdateDto, User>()
            .IgnoreNullValues(true) // faqat null bo'lmaganlarini yangilaydi
            .Map(dest => dest.FirstName, src => src.FirstName)
            .Map(dest => dest.LastName, src => src.LastName)
            .Map(dest => dest.MiddleName, src => src.MiddleName)
            .Map(dest => dest.PhoneNumber, src => src.PhoneNumber)
            .Map(dest => dest.Gender, src => src.Gender)
            .Map(dest => dest.Status, src => src.Status);
    }
}