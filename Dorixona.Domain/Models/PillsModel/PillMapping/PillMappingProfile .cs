using AutoMapper;
using Dorixona.Application.DTOs.Pills;
using Dorixona.Domain.Models.PillModel.PillDTO;
using Dorixona.Domain.Models.PillsModel.PillDTO;
using Dorixona.Domain.Models.PillsModel.PillEntities;

namespace Dorixona.Domain.Models.PillsModel.PillMapping;

public class PillMappingProfile : Profile
{
    public PillMappingProfile()
    {
        // DTO -> Entity
        CreateMap<CreatePillDto, Pill>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreateDate, opt => opt.Ignore())
            .ForMember(dest => dest.UpdateDate, opt => opt.Ignore());

        CreateMap<UpdatePillDto, Pill>()
            .ForMember(dest => dest.CreateDate, opt => opt.Ignore())
            .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(_ => DateTime.UtcNow));

        // Entity -> DTO
        CreateMap<Pill, PillDto>();

        CreateMap<Pill, FilterPillDto>();

        CreateMap<Pill, UpdatePillDto>();

        CreateMap<Pill, CreatePillDto>();

        CreateMap<Pill, PillShortDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}
