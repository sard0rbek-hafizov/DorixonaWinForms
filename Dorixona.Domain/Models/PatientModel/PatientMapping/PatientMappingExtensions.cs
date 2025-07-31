using AutoMapper;
using Mapster;
using Dorixona.Domain.Enums;
using Dorixona.Domain.Models.PatientModel.PatientDTO;
using Dorixona.Domain.Models.PatientModel.PatientEntities;

namespace Dorixona.Domain.Models.PatientModel.PatientMapping;

public class PatientMappingProfile : Profile
{
    public PatientMappingProfile()
    {
        // CreateDto -> Entity
        CreateMap<PatientCreateDto, Patient>()
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore()) // Parolni hashing controller/service da bo'ladi
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => Role.Patient))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => UserStatus.Active))
            .ForMember(dest => dest.IsEmailConfirmed, opt => opt.MapFrom(_ => false))
            .ForMember(dest => dest.IsPhoneConfirmed, opt => opt.MapFrom(_ => false))
            .ForMember(dest => dest.RegisteredAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(_ => false))
            .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForMember(dest => dest.DeleteDate, opt => opt.MapFrom(_ => (DateTime?)null));

        // Entity -> Dto
        CreateMap<Patient, PatientDto>();

        // UpdateDto -> Entity (update uchun)
        CreateMap<PatientUpdateDto, Patient>()
            .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(_ => DateTime.UtcNow))
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        // StatusUpdateDto -> Entity
        CreateMap<PatientStatusUpdateDto, Patient>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted))
            .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(_ => DateTime.UtcNow));


        // ChangePasswordDto -> Ignore (handled in Service layer)
        // Bu mapping emas, service-da alohida tekshiruv va hashing bilan bo'ladi.
    }
}
