using AutoMapper;
using Dorixona.Domain.Models.AdminModel.AdminDTO;

namespace Dorixona.Domain.Models.AdminModel.AdminMapping;

public class AdminFilterAndPaginationDtoProfile : Profile
{
    public AdminFilterAndPaginationDtoProfile()
    {
        CreateMap<AdminFilterDto, object>(); // filtering uchun model yaratsangiz, shu yerga qo‘ying
        CreateMap<AdminPaginationDto, object>(); // pagination modelga map qilish
    }
}
