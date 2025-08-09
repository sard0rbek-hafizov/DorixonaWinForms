using Dorixona.Domain.Models.PillsModel.PillEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dorixona.Infrastructure.Configurations;
public class PillConfiguration : IEntityTypeConfiguration<Pill>
{
    public void Configure(EntityTypeBuilder<Pill> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
        builder.Property(p => p.Manufacturer).HasMaxLength(150);
        builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
        builder.Property(p => p.ExpiryDate).IsRequired();
    }
}