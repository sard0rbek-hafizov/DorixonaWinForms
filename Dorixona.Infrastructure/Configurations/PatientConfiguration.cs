using Dorixona.Domain.Models.PatientModel.PatientEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dorixona.Infrastructure.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.Property(p => p.BirthDate).IsRequired();
        builder.Property(p => p.Gender).IsRequired();
    }
}
