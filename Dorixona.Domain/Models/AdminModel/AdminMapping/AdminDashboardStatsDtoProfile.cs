using AutoMapper;
using Dorixona.Domain.Models.AdminModel.AdminDTO;

namespace Dorixona.Domain.Models.AdminModel.AdminMapping;

public class AdminDashboardStatsDtoProfile : Profile
{
    public AdminDashboardStatsDtoProfile()
    {
        CreateMap<object, AdminDashboardStatsDto>() // yoki konkret DTO agar mavjud bo‘lsa
            .ForAllMembers(opts => opts.Ignore()); // customize qilingana qadar
    }
}
