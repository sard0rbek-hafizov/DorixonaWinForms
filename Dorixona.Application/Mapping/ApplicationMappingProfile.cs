using AutoMapper;
using Dorixona.Application.DTOs.Pills;
using Dorixona.Domain.Models.AdminModel.AdminDTO;
using Dorixona.Domain.Models.AdminModel.AdminEntities;
using Dorixona.Domain.Models.PatientModel.PatientDTO;
using Dorixona.Domain.Models.PatientModel.PatientEntities;
using Dorixona.Domain.Models.PharmacistModel.PharmacistDTO;
using Dorixona.Domain.Models.PharmacistModel.PharmacistEntities;
using Dorixona.Domain.Models.PharmacyModel.Entities;
using Dorixona.Domain.Models.PharmacyModel.PharmacyDTO;
using Dorixona.Domain.Models.PillsModel.PillEntities;
using Dorixona.Domain.Models.UserModel.UserEntities;
using Dorixona.Domain.Models.UsrModel.UserDTO;

namespace Dorixona.Application.Mapping;

public class ApplicationMappingProfile : Profile
{
    public ApplicationMappingProfile()
    {
        // User mappings
        CreateMap<User, UserDto>();
        CreateMap<UserCreateDto, User>();
        CreateMap<UserUpdateDto, User>();

        // Pill mappings
        CreateMap<Pill, PillDto>();
        CreateMap<CreatePillDto, Pill>();
        CreateMap<UpdatePillDto, Pill>();

        // Pharmcy mappings
        CreateMap<Pharmacy, PharmacyDto>();
        CreateMap<CreatePharmacyDto, Pharmacy>();
        CreateMap<UpdatePharmacyDto, Pharmacy>();

        // Admin mappings
        CreateMap<Admin, AdminDto>();
        CreateMap<AdminCreateDto, Admin>();
        CreateMap<AdminUpdateDto, Admin>();

        // Patient mappings
        CreateMap<Patient, PatientDto>();
        CreateMap<PatientCreateDto, Patient>();
        CreateMap<PatientUpdateDto, Patient>();

        // Pharmacist mappings
        CreateMap<Pharmacist, PharmacistDto>();
        CreateMap<PharmacistCreateDto, Pharmacist>();
        CreateMap<PharmacistUpdateDto, Pharmacist>();
    }
}
