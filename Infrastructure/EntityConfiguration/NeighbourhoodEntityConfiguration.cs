using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration;

public class NeighbourhoodEntityConfiguration : IEntityTypeConfiguration<Neighbourhood>
{
    public void Configure(EntityTypeBuilder<Neighbourhood> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Location).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Police).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Hospital).HasMaxLength(100).IsRequired();
        
    }
}