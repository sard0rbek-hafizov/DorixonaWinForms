using AutoMapper;
using Dorixona.Domain.Models.AdminModel.AdminDTO;

namespace Dorixona.Domain.Models.AdminModel.AdminMapping;

public class AdminSummaryDtoProfile : Profile
{
    public AdminSummaryDtoProfile()
    {
        CreateMap<(int total, int active, int blocked, AdminShortInfoDto last), AdminSummaryDto>()
            .ForMember(dest => dest.TotalAdmins, opt => opt.MapFrom(src => src.total))
            .ForMember(dest => dest.ActiveAdmins, opt => opt.MapFrom(src => src.active))
            .ForMember(dest => dest.BlockedAdmins, opt => opt.MapFrom(src => src.blocked))
            .ForMember(dest => dest.LastCreatedAdmin, opt => opt.MapFrom(src => src.last));
    }
}
