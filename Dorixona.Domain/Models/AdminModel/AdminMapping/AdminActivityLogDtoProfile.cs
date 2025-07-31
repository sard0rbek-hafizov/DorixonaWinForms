using AutoMapper;
using Dorixona.Domain.Models.AdminModel.AdminDTO;
using Dorixona.Domain.Models.AdminModel.AdminEntities;

namespace Dorixona.Domain.Models.AdminModel.AdminMapping;

public class AdminActivityLogDtoProfile : Profile
{
    public AdminActivityLogDtoProfile()
    {
        CreateMap<AdminActivityLogDto, AdminActivityLog>().ReverseMap();
    }
}
