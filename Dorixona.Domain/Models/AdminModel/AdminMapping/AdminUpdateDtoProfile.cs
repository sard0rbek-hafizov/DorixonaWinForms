using AutoMapper;
using Dorixona.Domain.Models.AdminModel.AdminDTO;
using Dorixona.Domain.Models.AdminModel.AdminEntities;

namespace Dorixona.Domain.Models.AdminModel.AdminMapping;

public class AdminUpdateDtoProfile : Profile
{
    public AdminUpdateDtoProfile()
    {
        CreateMap<AdminUpdateDto, Admin>();
    }
}
