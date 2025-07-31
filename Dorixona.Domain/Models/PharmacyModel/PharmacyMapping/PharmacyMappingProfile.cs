using AutoMapper;
using Dorixona.Domain.Models.PharmacyModel.Entities;
using Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;

namespace Dorixona.Domain.Models.PharmacyModel.PharmacyMapping;

public class PharmacyMappingProfile : Profile
{
    public PharmacyMappingProfile()
    {
        // CreatePharmacyDto -> Pharmacy
        CreateMap<CreatePharmacyDto, Pharmacy>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.CreateDate, opt => opt.Ignore())
            .ForMember(dest => dest.UpdateDate, opt => opt.Ignore());

        // UpdatePharmacyDto -> Pharmacy
        CreateMap<UpdatePharmacyDto, Pharmacy>()
            .ForMember(dest => dest.CreateDate, opt => opt.Ignore())
            .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(_ => DateTime.UtcNow));

        // Pharmacy -> PharmacyDto
        CreateMap<Pharmacy, PharmacyDto>();

        // Pharmacy -> FilterPharmacyDto
        CreateMap<Pharmacy, FilterPharmacyDto>();

        // Pharmacy -> UpdatePharmacyDto (for editing)
        CreateMap<Pharmacy, UpdatePharmacyDto>();

        // Pharmacy -> CreatePharmacyDto (optional: for duplication or default values)
        CreateMap<Pharmacy, CreatePharmacyDto>();

        // Pharmacy -> PharmacyShortDto (YANGI: qisqa ma'lumotlar uchun)
        CreateMap<Pharmacy, PharmacyShortDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}
