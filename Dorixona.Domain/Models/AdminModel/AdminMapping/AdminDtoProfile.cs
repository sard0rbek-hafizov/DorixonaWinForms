using AutoMapper;
using Dorixona.Domain.Models.AdminModel.AdminDTO;
using Dorixona.Domain.Models.AdminModel.AdminEntities;

namespace Dorixona.Domain.Models.AdminModel.AdminMapping;

public class AdminDtoProfile : Profile
{
    public AdminDtoProfile()
    {
        CreateMap<Admin, AdminDto>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.User!.FirstName} {src.User!.LastName}"))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User!.Email))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.User!.PhoneNumber))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.User!.Role.ToString()))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.User!.Status.ToString()));
    }
}
