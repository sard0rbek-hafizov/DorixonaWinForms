using AutoMapper;
using Dorixona.Domain.Models.AdminModel.AdminDTO;
using Dorixona.Domain.Models.AdminModel.AdminEntities;

namespace Dorixona.Domain.Models.AdminModel.AdminMapping;

public class AdminShortInfoDtoProfile : Profile
{
    public AdminShortInfoDtoProfile()
    {
        CreateMap<Admin, AdminShortInfoDto>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User!.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User!.LastName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User!.Email))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.User!.PhoneNumber))
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.User!.Role))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.User!.Status))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.User!.Gender));
    }
}
