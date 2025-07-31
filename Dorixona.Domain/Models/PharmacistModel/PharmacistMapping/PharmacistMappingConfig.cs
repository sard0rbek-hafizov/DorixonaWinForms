using Dorixona.Domain.Models.PharmacistModel.PharmacistDTO;
using Dorixona.Domain.Models.PharmacistModel.PharmacistEntities;
using Mapster;

namespace Dorixona.Domain.Models.PharmacistModel.PharmacistMapping;

public class PharmacistMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PharmacistCreateDto, Pharmacist>();
        config.NewConfig<PharmacistUpdateDto, Pharmacist>();
        config.NewConfig<Pharmacist, PharmacistDto>();
        config.NewConfig<Pharmacist, PharmacistDetailsDto>();
        config.NewConfig<Pharmacist, PharmacistListDto>();
        config.NewConfig<Pharmacist, PharmacistSummaryDto>();
    }
}
